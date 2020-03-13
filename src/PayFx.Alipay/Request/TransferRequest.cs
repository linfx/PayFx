using PayFx.Alipay.Domain;
using PayFx.Alipay.Response;

namespace PayFx.Alipay.Request
{
    public class TransferRequest : BaseRequest<TransferModel, TransferResponse>
    {
        public TransferRequest()
            : base("alipay.fund.trans.toaccount.transfer")
        {
        }
    }
}
