using Ray.ClipTool.Agent;
using Volo.Abp.DependencyInjection;

namespace Ray.ClipTool.AppService;

public class DouYinAppService : ITransientDependency
{
    private readonly IDouYinApi _douYinApi;

    public DouYinAppService(IDouYinApi douYinApi)
    {
        _douYinApi = douYinApi;
    }

    public async Task<string> DoAsync(string shareLink)
    {
        var videoId = await GetVideoIdFromShareLinkAsync(shareLink);

        var videoInfo = GetClipDetailInfo(videoId);

        return GetNoWaterMarkUrl(videoInfo);
    }

    private async Task<string> GetVideoIdFromShareLinkAsync(string shareLink)
    {
        var code = shareLink;

        var re=await _douYinApi.VisitShareLinkAsync(code);
        return "";
    }

    private string GetClipDetailInfo(string videoId)
    {
        return "";
    }

    private string GetNoWaterMarkUrl(string videoId)
    {
        return $"{DateTime.Now:s} Hello, World!";
    }
}