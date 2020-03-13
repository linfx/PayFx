using PayFx.Alipay.Domain;
using PayFx.Alipay.Response;

namespace PayFx.Alipay.Request
{
    public class WebPayRequest : BaseRequest<WebPayModel, WebPayResponse>
    {
        public WebPayRequest()
            : base("alipay.trade.page.pay")
        {
        }
    }
}
