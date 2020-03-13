using PayFx.Alipay.Domain;
using PayFx.Alipay.Response;

namespace PayFx.Alipay.Request
{
    public class WapPayRequest : BaseRequest<WapPayModel, WapPayResponse>
    {
        public WapPayRequest()
            : base("alipay.trade.wap.pay")
        {
        }
    }
}
