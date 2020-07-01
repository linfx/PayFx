using System;
using PayFx.Http;
using PayFx.Utils;

namespace PayFx
{
    /// <summary>
    /// 事件数据的基类
    /// </summary>
    public abstract class NotifyEventArgs : EventArgs
    {
        protected Gateway Gateway;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="gateway">支付网关</param>
        protected NotifyEventArgs(Gateway gateway)
        {
            Gateway = gateway;
            NotifyServerHostAddress = HttpUtil.RemoteIpAddress;
        }

        /// <summary>
        /// 发送支付通知的网关IP地址
        /// </summary>
        public string NotifyServerHostAddress { get; private set; }

        /// <summary>
        /// 网关的数据
        /// </summary>
        public GatewayData GatewayData => Gateway.GatewayData;

        /// <summary>
        /// 网关类型
        /// </summary>
        public Type GatewayType => Gateway.GetType();

        /// <summary>
        /// 通知数据
        /// </summary>
        public IResponse NotifyResponse => Gateway.NotifyResponse;

        /// <summary>
        /// 通知类型
        /// </summary>
        public NotifyType NotifyType => HttpUtil.RequestType == "GET" ? NotifyType.Sync : NotifyType.Async;
    }
}
