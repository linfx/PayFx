using PayFx.Unionpay.Domain;
using PayFx.Unionpay.Response;

namespace PayFx.Unionpay.Request
{
    public class AppPayRequest : BaseRequest<AppPayModel, AppPayResponse>
    {
        public AppPayRequest()
        {
            RequestUri = "/gateway/api/appTransReq.do";
        }
    }
}
