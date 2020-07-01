using PayFx.Unionpay.Domain;
using PayFx.Unionpay.Response;

namespace PayFx.Unionpay.Request
{
    public class RefundRequest : BaseRequest<RefundModel, RefundResponse>
    {
        public RefundRequest()
        {
            RequestUri = "/gateway/api/backTransReq.do";
        }

        internal override void Execute(Merchant merchant)
        {
            GatewayData.Remove("frontUrl");
        }
    }
}
