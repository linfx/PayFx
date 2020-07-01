namespace PayFx.Unionpay.Response
{
    public class ScanPayResponse : BaseResponse
    {
        /// <summary>
        /// 二维码
        /// </summary>
        public string QrCode { get; set; }
    }
}
