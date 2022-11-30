using Volo.Abp.DependencyInjection;

namespace Ray.ClipTool;

public class HelloWorldService : ITransientDependency
{
    public string SayHello()
    {
        return "Hello, World!";
    }
}