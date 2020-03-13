using PayFx.Wechatpay.Domain;
using PayFx.Wechatpay.Response;

namespace PayFx.Wechatpay.Request
{
    public class CancelRequest : BaseRequest<CancelModel, CancelResponse>
    {
        public CancelRequest()
        {
            RequestUrl = "/secapi/pay/reverse";
            IsUseCert = true;
        }

        internal override void Execute(Merchant merchant)
        {
            GatewayData.Remove("notify_url");
        }
    }
}
