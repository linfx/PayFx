using PayFx.Wechatpay.Domain;
using PayFx.Wechatpay.Response;

namespace PayFx.Wechatpay.Request
{
    public class TransferToBankQueryRequest : BaseRequest<TransferToBankQueryModel, TransferToBankQueryResponse>
    {
        public TransferToBankQueryRequest()
        {
            RequestUrl = "/mmpaysptrans/query_bank";
            IsUseCert = true;
        }

        internal override void Execute(Merchant merchant)
        {
            GatewayData.Remove("notify_url");
            GatewayData.Remove("appid");
            GatewayData.Remove("sign_type");
        }
    }
}
