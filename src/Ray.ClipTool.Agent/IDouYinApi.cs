using Refit;

namespace Ray.ClipTool.Agent
{
    public interface IDouYinApi
    {
        [Get("/{code}")]
        Task<HttpResponseMessage> VisitShareLinkAsync(string code);
    }
}