using System;
using Microsoft.Extensions.Configuration;
using PayFx;
using PayFx.Wechatpay;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IGateways UseWechatpay(this IGateways gateways, Action<Merchant> action)
        {
            if (action != null)
            {
                var merchant = new Merchant();
                action(merchant);
                gateways.Add(new WechatpayGateway(merchant));
            }
            return gateways;
        }

        public static IGateways UseWechatpay(this IGateways gateways, IConfiguration configuration)
        {
            var merchants = configuration.GetSection("PayFx:Wechatpays").Get<Merchant[]>();
            if (merchants != null)
            {
                for (var i = 0; i < merchants.Length; i++)
                {
                    var wechatpayGateway = new WechatpayGateway(merchants[i]);
                    var gatewayUrl = configuration.GetSection($"PayFx:Wechatpays:{i}:GatewayUrl").Value;
                    if (!string.IsNullOrEmpty(gatewayUrl))
                    {
                        wechatpayGateway.GatewayUrl = gatewayUrl;
                    }
                    gateways.Add(wechatpayGateway);
                }
            }
            return gateways;
        }
    }
}
