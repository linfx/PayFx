namespace PayFx
{
    public class RefundSucceedEventArgs : NotifyEventArgs
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="gateway">支付网关</param>
        public RefundSucceedEventArgs(Gateway gateway)
            : base(gateway) { }
    }
}
