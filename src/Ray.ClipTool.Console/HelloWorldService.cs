using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Ray.ClipTool.AppService;
using Volo.Abp.DependencyInjection;

namespace Ray.ClipTool.Console;

public class HelloWorldService : ITransientDependency
{
    private readonly DouYinAppService _douYinAppService;
    public ILogger<HelloWorldService> Logger { get; set; }

    public HelloWorldService(DouYinAppService douYinAppService)
    {
        _douYinAppService = douYinAppService;
        Logger = NullLogger<HelloWorldService>.Instance;
    }

    public async Task SayHelloAsync()
    {
        Logger.LogInformation("Hello World!");

        await _douYinAppService.DoAsync("rw7sEKJ");

    }
}
