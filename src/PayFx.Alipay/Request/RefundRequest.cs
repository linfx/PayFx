using PayFx.Alipay.Domain;
using PayFx.Alipay.Response;

namespace PayFx.Alipay.Request
{
    public class RefundRequest : BaseRequest<RefundModel, RefundResponse>
    {
        public RefundRequest()
            : base("alipay.trade.refund")
        {
        }
    }
}
