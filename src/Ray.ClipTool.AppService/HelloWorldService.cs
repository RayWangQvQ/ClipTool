using Volo.Abp.DependencyInjection;

namespace Ray.ClipTool.AppService;

public class HelloWorldService : ITransientDependency
{
    public string SayHello()
    {
        return "Hello, World!";
    }
}