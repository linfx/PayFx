namespace PayFx
{
    public class CancelSucceedEventArgs : NotifyEventArgs
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="gateway">支付网关</param>
        public CancelSucceedEventArgs(Gateway gateway) : base(gateway) { }
    }
}
