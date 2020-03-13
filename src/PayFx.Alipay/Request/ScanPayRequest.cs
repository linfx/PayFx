using PayFx.Alipay.Domain;
using PayFx.Alipay.Response;

namespace PayFx.Alipay.Request
{
    public class ScanPayRequest : BaseRequest<ScanPayModel, ScanPayResponse>
    {
        public ScanPayRequest()
            : base("alipay.trade.precreate")
        {
        }
    }
}
