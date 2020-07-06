namespace PayFx.Unionpay.Domain
{
    public class BarcodePayModel : ScanPayModel
    {
        public BarcodePayModel()
        {
            TxnType = "01";
            TxnSubType = "06";
            BizType = "000000";
        }

        /// <summary>
        /// 二维码编号
        /// </summary>
        public string QrNo { get; set; }
    }
}
