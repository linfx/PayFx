﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PayFx.Alipay.Response;
using PayFx.Http;
using PayFx.Utils;

namespace PayFx.Alipay
{
    internal static class SubmitProcess
    {
        private static string _gatewayUrl;

        internal static TResponse Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request, string gatewayUrl = null) where TResponse : IResponse
        {
            AddMerchant(merchant, request, gatewayUrl);

            var result = HttpUtil.Post(request.RequestUri, request.GatewayData.ToUrl());

            var jObject = JObject.Parse(result);
            var jToken = jObject.First.First;
            var sign = jObject.Value<string>("sign");
            if (!string.IsNullOrEmpty(sign) && !CheckSign(jToken.ToString(Formatting.None), sign, merchant.AlipayPublicKey, merchant.SignType))
            {
                throw new PayFxException("签名验证失败");
            }

            var baseResponse = (BaseResponse)jToken.ToObject(typeof(TResponse));
            baseResponse.Raw = result;
            baseResponse.Sign = sign;
            baseResponse.Execute(merchant, request);
            return (TResponse)(object)baseResponse;
        }

        internal static TResponse SdkExecute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request, string gatewayUrl) where TResponse : IResponse
        {
            AddMerchant(merchant, request, gatewayUrl);

            return (TResponse)Activator.CreateInstance(typeof(TResponse), request);
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
            request.GatewayData.Add(merchant, StringCase.Snake);
            if (!string.IsNullOrEmpty(request.NotifyUrl))
            {
                request.GatewayData.Add("notify_url", request.NotifyUrl);
            }
            if (!string.IsNullOrEmpty(request.ReturnUrl))
            {
                request.GatewayData.Add("return_url", request.ReturnUrl);
            }
            request.GatewayData.Add("sign", BuildSign(request.GatewayData, merchant.Privatekey, merchant.SignType));
        }

        internal static string BuildSign(GatewayData gatewayData, string privatekey, string signType)
        {
            gatewayData.Remove("sign");
            return EncryptUtil.RSA(gatewayData.ToUrl(false), privatekey, signType);
        }

        internal static bool CheckSign(string data, string sign, string alipayPublicKey, string signType)
        {
            var result = EncryptUtil.RSAVerifyData(data, sign, alipayPublicKey, signType);
            if (!result)
            {
                data = data.Replace("/", "\\/");
                result = EncryptUtil.RSAVerifyData(data, sign, alipayPublicKey, signType);
            }

            return result;
        }
    }
}
