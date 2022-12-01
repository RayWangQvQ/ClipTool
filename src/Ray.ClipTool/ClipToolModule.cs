using Ray.ClipTool.AppService;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Ray.ClipTool;

[DependsOn(typeof(AbpAutofacModule),
    typeof(ClipToolAppServiceModule))]
public class ClipToolModule : AbpModule
{
}
