using PayFx.Http;
using PayFx.Unionpay.Request;

namespace PayFx.Unionpay.Response
{
    public class WapPayResponse : IResponse
    {
        public WapPayResponse(WapPayRequest request)
        {
            Html = request.GatewayData.ToForm(request.RequestUri);
        }

        /// <summary>
        /// 生成的Html网页
        /// </summary>
        public string Html { get; set; }

        public string Raw { get; set; }
    }
}
