using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Ray.ClipTool.Agent;
using Ray.ClipTool.Agent.DouYin;
using Ray.ClipTool.AppService.Helpers;
using System;
using Volo.Abp.DependencyInjection;

namespace Ray.ClipTool.AppService;

public class DouYinAppService : ITransientDependency
{
    private readonly IVDouYinApi _ivDouYinApi;
    private readonly IIesDouYinApi _iesDouYinApi;

    public DouYinAppService(IVDouYinApi ivDouYinApi, IIesDouYinApi iesDouYinApi)
    {
        _ivDouYinApi = ivDouYinApi;
        _iesDouYinApi = iesDouYinApi;
        Logger = NullLogger<DouYinAppService>.Instance;
    }

    public ILogger<DouYinAppService> Logger { get; set; }

    public async Task<string> DoAsync(string shareLink)
    {
        Logger.LogInformation("The original share text: {share}", shareLink);

        var videoId = await GetVideoIdFromShareLinkAsync(shareLink);

        var videoInfo = await GetClipDetailInfoAsync(videoId);

        return GetNoWaterMarkUrl(videoInfo);
    }

    private async Task<string> GetVideoIdFromShareLinkAsync(string shareLink)
    {
        var code = RegexHelper.SubstringSingle(shareLink, "https://v.douyin.com/", "/");

        //var re = await _douYinApi.VisitShareLinkAsync(code);
        var re = _ivDouYinApi.VisitShareLinkAsync(code).Result;

        var id = re.RequestMessage.RequestUri.AbsolutePath.Replace("/video/", "");
        Logger.LogInformation("Video Id:{id}", id);
        return id;
    }

    private async Task<string> GetClipDetailInfoAsync(string videoId)
    {
        var re = await _iesDouYinApi.DetailInfoAsync(videoId);
        var url = re.item_list
            .FirstOrDefault()
            ?.video
            .play_addr
            .url_list
            .FirstOrDefault();
        Logger.LogInformation("url: {url}",url);
        return url ?? "";
    }

    private string GetNoWaterMarkUrl(string source)
    {
        source = source.Replace("playwm", "play");
        Logger.LogInformation("url without water mark: {url}",source);
        return source;
    }
}