using PayFx.Alipay.Request;
using PayFx.Response;

namespace PayFx.Alipay.Response
{
    public class WapPayResponse : IResponse
    {
        public WapPayResponse(WapPayRequest request)
        {
            Url = $"{request.RequestUrl}&{request.GatewayData.ToUrl()}";
        }

        /// <summary>
        /// 跳转链接
        /// </summary>
        public string Url { get; set; }

        public string Raw { get; set; }
    }
}
