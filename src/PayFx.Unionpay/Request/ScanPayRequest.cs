using PayFx.Unionpay.Domain;
using PayFx.Unionpay.Response;

namespace PayFx.Unionpay.Request
{
    public class ScanPayRequest : BaseRequest<ScanPayModel, ScanPayResponse>
    {
        public ScanPayRequest()
        {
            RequestUri = "/gateway/api/backTransReq.do";
        }
    }
}
