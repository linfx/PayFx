using System;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto;
using PayFx.Http;
using PayFx.Unionpay.Request;
using PayFx.Unionpay.Response;
using PayFx.Utils;

namespace PayFx.Unionpay
{
    internal static class SubmitProcess
    {
        private static string _gatewayUrl;

        internal static async Task<TResponse> ExecuteAsync<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request, string gatewayUrl = null) where TResponse : IResponse
        {
            AddMerchant(merchant, request, gatewayUrl);

            var content = await HttpUtil.PostAsync(request.RequestUri, request.GatewayData);
            var result = await content.ReadAsStringAsync();

            var gatewayData = new GatewayData(StringComparer.Ordinal);
            gatewayData.FromUrl(result, false);

            var baseResponse = (BaseResponse)(object)gatewayData.ToObject<TResponse>(StringCase.Camel);
            baseResponse.Raw = result;

            var sign = gatewayData.GetStringValue("signature");
            if (!string.IsNullOrEmpty(sign) && !CheckSign(gatewayData, sign, baseResponse.SignPubKeyCert))
            {
                throw new PayFxException("签名验证失败");
            }

            baseResponse.Sign = sign;
            baseResponse.Execute(merchant, request);

            return (TResponse)(object)baseResponse;
        }

        internal static TResponse SdkExecute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request, string gatewayUrl) where TResponse : IResponse
        {
            AddMerchant(merchant, request, gatewayUrl);
            return (TResponse)Activator.CreateInstance(typeof(TResponse), request);
        }

        internal static Task<TResponse> SdkExecuteAsync<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request, string gatewayUrl) where TResponse : IResponse
        {
            AddMerchant(merchant, request, gatewayUrl);
            return Task.FromResult((TResponse)Activator.CreateInstance(typeof(TResponse), request));
        }

        private static void AddMerchant<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request, string gatewayUrl) where TResponse : IResponse
        {
            if (!string.IsNullOrEmpty(gatewayUrl))
            {
                _gatewayUrl = gatewayUrl;
            }

            if (!request.RequestUri.StartsWith("http"))
            {
                request.RequestUri = _gatewayUrl + request.RequestUri;
            }

            request.GatewayData.Add(merchant, StringCase.Camel);

            if (!string.IsNullOrEmpty(request.NotifyUrl))
            {
                request.GatewayData.Add("backUrl", request.NotifyUrl);
            }
            if (!string.IsNullOrEmpty(request.ReturnUrl))
            {
                request.GatewayData.Add("frontUrl", request.ReturnUrl);
            }

            ((BaseRequest<TModel, TResponse>)request).Execute(merchant);

            request.GatewayData.Add("signature", BuildSign(request.GatewayData, merchant.CertKey));
        }

        internal static string BuildSign(GatewayData gatewayData, AsymmetricKeyParameter asymmetricKeyParameter)
        {
            gatewayData.Remove("signature");
            return Util.Sign(asymmetricKeyParameter, gatewayData.ToUrl(false));
        }

        internal static bool CheckSign(GatewayData gatewayData, string sign, string signPubKeyCert)
        {
            gatewayData.Remove("signature");
            return Util.VerifyData(gatewayData.ToUrl(false), sign, signPubKeyCert);
        }
    }
}
