using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PayFx.Request;
using PayFx.Utils;
using PayFx.Unionpay.Request;
using PayFx.Unionpay.Response;

namespace PayFx.Unionpay
{
    /// <summary>
    /// 中国银联网关
    /// </summary>
    public sealed class UnionpayGateway : BaseGateway
    {

        /// <summary>
        /// 初始化中国银联网关
        /// </summary>
        /// <param name="merchant">商户数据</param>
        public UnionpayGateway(Merchant merchant)
            : base(merchant)
        {
            Merchant = merchant;
            Merchant.CertId = Util.GetCertId(merchant.CertPath, merchant.CertPwd);
            Merchant.CertKey = Util.GetCertKey(merchant.CertPath, merchant.CertPwd);
        }

        /// <summary>
        /// 初始化中国银联网关
        /// </summary>
        /// <param name="merchant">商户数据</param>
        public UnionpayGateway(IOptions<Merchant> merchant)
           : this(merchant.Value) { }

        public override string GatewayUrl { get; set; } = "https://gateway.test.95516.com";

        public new Merchant Merchant { get; }

        public new NotifyResponse NotifyResponse => (NotifyResponse)base.NotifyResponse;

        protected override bool IsPaySuccess => NotifyResponse.TxnType == "01" && NotifyResponse.RespCode == "00";

        protected override bool IsRefundSuccess => NotifyResponse.TxnType == "04" && NotifyResponse.RespCode == "00";

        protected override bool IsCancelSuccess => NotifyResponse.TxnType == "31" && NotifyResponse.RespCode == "00";

        protected override string[] NotifyVerifyParameter => new string[]
        {
            "merId",  "respCode", "respMsg", "queryId", "signMethod"
        };

        protected override async Task<bool> ValidateNotifyAsync()
        {
            base.NotifyResponse = (PayFx.Response.IResponse)await GatewayData.ToObjectAsync<NotifyResponse>(StringCase.Camel);
            base.NotifyResponse.Raw = GatewayData.ToUrl(false);

            var gatewayData = new GatewayData(StringComparer.Ordinal);
            gatewayData.FromUrl(NotifyResponse.Raw, false);
            return SubmitProcess.CheckSign(gatewayData, NotifyResponse.Sign, NotifyResponse.SignPubKeyCert);
        }

        public override TResponse Execute<TModel, TResponse>(Request<TModel, TResponse> request)
        {
            if (request is WebPayRequest || request is WapPayRequest)
            {
                return SubmitProcess.SdkExecute(Merchant, request, GatewayUrl);
            }

            return SubmitProcess.Execute(Merchant, request, GatewayUrl);
        }

        protected override void WriteFailureFlag()
        {
            HttpUtil.Current.Response.StatusCode = 404;
        }
    }
}
