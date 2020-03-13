using PayFx.Alipay.Domain;
using PayFx.Alipay.Response;

namespace PayFx.Alipay.Request
{
    public class TransferQueryRequest : BaseRequest<TransferQueryModel, TransferQueryResponse>
    {
        public TransferQueryRequest()
            : base("alipay.fund.trans.order.query")
        {
        }
    }
}
