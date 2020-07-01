using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using PayFx;
using PayFx.Utils;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加PayFx
        /// </summary>
        /// <param name="services"></param>
        /// <param name="setupAction"></param>
        public static void AddPayFx(this IServiceCollection services, Action<IGateways> setupAction)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IGateways>(a =>
            {
                var gateways = new Gateways();
                setupAction(gateways);
                return gateways;
            });
        }

        /// <summary>
        /// 使用PayFx
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UsePayFx(this IApplicationBuilder app)
        {
            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            HttpUtil.Configure(httpContextAccessor);
            return app;
        }
    }
}
