using PayFx.Wechatpay.Domain;
using PayFx.Wechatpay.Response;

namespace PayFx.Wechatpay.Request
{
    public class RefundQueryRequest : BaseRequest<RefundQueryModel, RefundQueryResponse>
    {
        public RefundQueryRequest()
        {
            RequestUrl = "/pay/refundquery";
        }

        internal override void Execute(Merchant merchant)
        {
            GatewayData.Remove("notify_url");
        }
    }
}
