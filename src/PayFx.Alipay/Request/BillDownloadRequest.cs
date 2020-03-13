using PayFx.Alipay.Domain;
using PayFx.Alipay.Response;

namespace PayFx.Alipay.Request
{
    public class BillDownloadRequest : BaseRequest<BillDownloadModel, BillDownloadResponse>
    {
        public BillDownloadRequest()
            : base("alipay.data.dataservice.bill.downloadurl.query")
        {
        }
    }
}
