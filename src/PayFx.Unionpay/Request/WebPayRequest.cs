using PayFx.Unionpay.Domain;
using PayFx.Unionpay.Response;

namespace PayFx.Unionpay.Request
{
    public class WebPayRequest : BaseRequest<WebPayModel, WebPayResponse>
    {
        public WebPayRequest()
        {
            RequestUri = "/gateway/api/frontTransReq.do";
        }
    }
}
