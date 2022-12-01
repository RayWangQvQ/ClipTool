using Ray.ClipTool.Agent;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Ray.ClipTool.AppService;

[DependsOn(typeof(AbpAutofacModule),
    typeof(ClipToolAgentModule))]
public class ClipToolAppServiceModule : AbpModule
{
}
