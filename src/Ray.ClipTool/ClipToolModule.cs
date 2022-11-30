using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Ray.ClipTool;

[DependsOn(typeof(AbpAutofacModule))]
public class ClipToolModule : AbpModule
{
}
