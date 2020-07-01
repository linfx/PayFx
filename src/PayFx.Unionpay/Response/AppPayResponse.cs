namespace PayFx.Unionpay.Response
{
    public class AppPayResponse : BaseResponse
    {
        /// <summary>
        /// 银联受理订单号
        /// </summary>
        public string Tn { get; set; }
    }
}
