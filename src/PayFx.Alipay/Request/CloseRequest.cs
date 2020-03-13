using PayFx.Alipay.Domain;
using PayFx.Alipay.Response;

namespace PayFx.Alipay.Request
{
    public class CloseRequest : BaseRequest<CloseModel, CloseResponse>
    {
        public CloseRequest()
            : base("alipay.trade.close")
        {
        }
    }
}
