namespace PayFx
{
    public class UnKnownNotifyEventArgs : NotifyEventArgs
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="gateway">支付网关</param>
        public UnKnownNotifyEventArgs(Gateway gateway)
            : base(gateway) { }

        public string Message { get; set; }
    }
}
