using Volo.Abp.DependencyInjection;

namespace Ray.ClipTool.AppService;

public class DouYinAppService : ITransientDependency
{
    public string Do(string shareLink)
    {
        var videoId = GetVideoIdFromShareLink(shareLink);

        var videoInfo = GetClipDetailInfo(videoId);

        return GetNoWaterMarkUrl(videoInfo);
    }

    private string GetVideoIdFromShareLink(string shareLink)
    {
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