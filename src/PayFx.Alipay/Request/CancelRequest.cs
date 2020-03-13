using PayFx.Alipay.Domain;
using PayFx.Alipay.Response;

namespace PayFx.Alipay.Request
{
    public class CancelRequest : BaseRequest<CancelModel, CancelResponse>
    {
        public CancelRequest()
            : base("alipay.trade.cancel")
        {
        }
    }
}
