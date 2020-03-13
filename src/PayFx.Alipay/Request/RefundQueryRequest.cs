using PayFx.Alipay.Domain;
using PayFx.Alipay.Response;

namespace PayFx.Alipay.Request
{
    public class RefundQueryRequest : BaseRequest<RefundQueryModel, RefundQueryResponse>
    {
        public RefundQueryRequest()
            : base("alipay.trade.fastpay.refund.query")
        {
        }
    }
}
