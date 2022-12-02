using Refit;

namespace Ray.ClipTool.Agent.DouYin
{
    public interface IVDouYinApi
    {
        [Get("/{code}/")]
        Task<HttpResponseMessage> VisitShareLinkAsync(string code);
    }
}