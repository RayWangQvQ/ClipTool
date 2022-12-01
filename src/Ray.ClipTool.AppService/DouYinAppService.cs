using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Ray.ClipTool.Agent;
using Volo.Abp.DependencyInjection;

namespace Ray.ClipTool.AppService;

public class DouYinAppService : ITransientDependency
{
    private readonly IDouYinApi _douYinApi;

    public DouYinAppService(IDouYinApi douYinApi)
    {
        _douYinApi = douYinApi;
        Logger = NullLogger<DouYinAppService>.Instance;
    }

    public ILogger<DouYinAppService> Logger { get; set; }

    public async Task<string> DoAsync(string shareLink)
    {
        var videoId = await GetVideoIdFromShareLinkAsync(shareLink);

        var videoInfo = GetClipDetailInfo(videoId);

        return GetNoWaterMarkUrl(videoInfo);
    }

    private async Task<string> GetVideoIdFromShareLinkAsync(string shareLink)
    {
        var code = shareLink;

        //var re = await _douYinApi.VisitShareLinkAsync(code);
        var re = _douYinApi.VisitShareLinkAsync(code).Result;

        var id = re.RequestMessage.RequestUri.AbsolutePath.Replace("/video/", "");
        Logger.LogInformation("Video Id:{id}", id);
        return id;
    }

    private string GetClipDetailInfo(string videoId)
    {
        return videoId;
    }

    private string GetNoWaterMarkUrl(string videoId)
    {
        return $"{DateTime.Now:s} {videoId}";
    }
}