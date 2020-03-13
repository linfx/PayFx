using PayFx.Alipay.Domain;
using PayFx.Alipay.Response;

namespace PayFx.Alipay.Request
{
    public class AppPayRequest : BaseRequest<AppPayModel, AppPayResponse>
    {
        public AppPayRequest()
            : base("alipay.trade.app.pay")
        {
        }
    }
}
