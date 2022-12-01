using Microsoft.Extensions.DependencyInjection;
using Refit;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Ray.ClipTool.Agent;

[DependsOn(typeof(AbpAutofacModule))]
public class ClipToolAgentModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        base.ConfigureServices(context);

        var settings = new RefitSettings();
        // Configure refit settings here

        context.Services.AddRefitClient<IDouYinApi>(settings)
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://v.douyin.com");
                c.DefaultRequestHeaders.UserAgent.TryParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36 Edg/107.0.1418.62");
            });
        // Add additional IHttpClientBuilder chained methods as required here:
        // .AddHttpMessageHandler<MyHandler>()
        // .SetHandlerLifetime(TimeSpan.FromMinutes(2));
    }
}
