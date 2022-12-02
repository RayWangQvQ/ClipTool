using Microsoft.Extensions.DependencyInjection;
using Ray.ClipTool.Agent.DouYin;
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

        var defaultUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36 Edg/107.0.1418.62";
        var settings = new RefitSettings();

        context.Services.AddRefitClient<IVDouYinApi>(settings)
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://v.douyin.com");
                c.DefaultRequestHeaders.UserAgent.TryParseAdd(defaultUserAgent);
            });

        context.Services.AddRefitClient<IIesDouYinApi>(settings)
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://www.iesdouyin.com");
                c.DefaultRequestHeaders.UserAgent.TryParseAdd(defaultUserAgent);
            });
    }
}
