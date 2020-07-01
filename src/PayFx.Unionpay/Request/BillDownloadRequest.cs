using PayFx.Unionpay.Domain;
using PayFx.Unionpay.Response;

namespace PayFx.Unionpay.Request
{
    public class BillDownloadRequest : BaseRequest<BillDownloadModel, BillDownloadResponse>
    {
        public BillDownloadRequest()
        {
            RequestUri = "https://filedownload.95516.com/";
        }

        internal override void Execute(Merchant merchant)
        {
            GatewayData.Remove("backUrl");
            GatewayData.Remove("frontUrl");
        }
    }
}
