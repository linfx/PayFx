using PayFx.Wechatpay.Domain;
using PayFx.Wechatpay.Response;

namespace PayFx.Wechatpay.Request
{
    public class FundFlowDownloadRequest : BaseRequest<FundFlowDownloadModel, FundFlowDownloadResponse>
    {
        public FundFlowDownloadRequest()
        {
            RequestUri = "/pay/downloadfundflow";
            IsUseCert = true;
        }

        internal override void Execute(Merchant merchant)
        {
            GatewayData.Remove("notify_url");
            GatewayData.Add("sign_type", "HMAC-SHA256");
        }
    }
}
