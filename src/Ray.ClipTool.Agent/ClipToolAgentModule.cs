using Microsoft.Extensions.DependencyInjection;
using Refit;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Ray.ClipTool.Agent;

[DependsOn(typeof(AbpAutofacModule))]
public class ClipToolAgentModule : AbpModule
{
    public override Task ConfigureServicesAsync(ServiceConfigurationContext context)
    {
        var settings = new RefitSettings();
        // Configure refit settings here

        context.Services.AddRefitClient<IDouYinApi>(settings)
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://v.douyin.com"));
        // Add additional IHttpClientBuilder chained methods as required here:
        // .AddHttpMessageHandler<MyHandler>()
        // .SetHandlerLifetime(TimeSpan.FromMinutes(2));

        return base.ConfigureServicesAsync(context);
    }
}
