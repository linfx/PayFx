using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PayFx.Http;
using PayFx.Utils;
using PayFx.Wechatpay.Request;
using PayFx.Wechatpay.Response;
using static PayFx.Wechatpay.Response.QueryResponse;

namespace PayFx.Wechatpay
{
    /// <summary>
    /// 微信支付网关
    /// </summary>
    public sealed class WechatpayGateway : Gateway
    {
        /// <summary>
        /// 初始化微信支付网关
        /// </summary>
        /// <param name="merchant">商户数据</param>
        public WechatpayGateway(Merchant merchant)
            : base(merchant)
        {
            Merchant = merchant;
        }

        /// <summary>
        /// 初始化微信支付网关
        /// </summary>
        /// <param name="merchant">商户数据</param>
        public WechatpayGateway(IOptions<Merchant> merchant)
            : this(merchant.Value) { }

        public override string GatewayUrl { get; set; } = "https://api.mch.weixin.qq.com";

        public new Merchant Merchant { get; }

        public new NotifyResponse NotifyResponse => (NotifyResponse)base.NotifyResponse;

        protected override bool IsPaySuccess => NotifyResponse.ResultCode == "SUCCESS" && !string.IsNullOrEmpty(NotifyResponse.TradeType);

        protected override bool IsRefundSuccess => NotifyResponse.RefundStatus == "SUCCESS";

        protected override bool IsCancelSuccess { get; }

        protected override string[] NotifyVerifyParameter => new string[]
        {
            "appid", "return_code", "mch_id", "nonce_str"
        };

        protected override async Task<bool> ValidateNotifyAsync()
        {
            base.NotifyResponse = await GatewayData.ToObjectAsync<NotifyResponse>(StringCase.Snake);
            base.NotifyResponse.Raw = GatewayData.Raw;

            if (NotifyResponse.ReturnCode != "SUCCESS")
            {
                throw new PayFxException("不是成功的返回码");
            }

            if (string.IsNullOrEmpty(NotifyResponse.ReqInfo))
            {
                NotifyResponse.Coupons = ConvertUtil.ToList<CouponResponse, object>(GatewayData, -1);
                if (NotifyResponse.Sign != SubmitProcess.BuildSign(GatewayData, Merchant.Key))
                {
                    throw new PayFxException("签名不一致");
                }
            }
            else
            {
                var tempNotify = NotifyResponse;
                var key = EncryptUtil.MD5(Merchant.Key).ToLower();
                var data = EncryptUtil.AESDecrypt(NotifyResponse.ReqInfo, key);
                var gatewayData = new GatewayData();
                gatewayData.FromXml(data);
                base.NotifyResponse = await gatewayData.ToObjectAsync<NotifyResponse>(StringCase.Snake);
                GatewayData.Add(NotifyResponse, StringCase.Snake);

                NotifyResponse.AppId = tempNotify.AppId;
                NotifyResponse.MchId = tempNotify.MchId;
                NotifyResponse.NonceStr = tempNotify.NonceStr;
                NotifyResponse.ReqInfo = tempNotify.ReqInfo;
                NotifyResponse.ReturnCode = tempNotify.ReturnCode;
            }

            return true;
        }

        protected override void WriteSuccessFlag()
        {
            GatewayData.Clear();
            GatewayData.Add("return_code", "SUCCESS");
            GatewayData.Add("return_msg", "OK");
            HttpUtil.Write(GatewayData.ToXml());
        }

        protected override void WriteFailureFlag()
        {
            GatewayData.Clear();
            GatewayData.Add("return_code", "FAIL");
            HttpUtil.Write(GatewayData.ToXml());
        }

        public override TResponse Execute<TModel, TResponse>(Request<TModel, TResponse> request)
        {
            if (request is OAuthRequest)
            {
                return SubmitProcess.AuthExecute(Merchant, request, GatewayUrl);
            }

            return SubmitProcess.Execute(Merchant, request, GatewayUrl);
        }
    }
}
