using System.Security.Claims;
using CjApp.Enum;
using CjApp.Helper;
using CjApp.IService;
using CjApp.Model;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace CjApp.Controllers;

/// <summary>
/// 文章控制器
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ArticleController : ControllerBase
{
    private static readonly IMemoryCache MemoryCache = new MemoryCache(new MemoryCacheOptions());
    private static readonly ILog Log = LogManager.GetLogger("article");
    private readonly IArticleService _articleService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="articleService"></param>
    /// <param name="httpContextAccessor"></param>
    public ArticleController(IArticleService articleService, IHttpContextAccessor httpContextAccessor)
    {
        _articleService = articleService;
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// 根据id获取文章信息
    /// </summary>
    /// <param name="id">id</param>
    /// <returns></returns>
    [HttpGet, Route("get/{id}")]
    [ApiExplorerSettings(GroupName = nameof(ApiVersion.v1))]
    public async Task<ApiResult> GetById(string id)
    {
        Log.Info($"GetById/{id}");
        if (MemoryCache.TryGetValue(id, out Article data))
        {
            return ApiResultHelper.Success(data);
        }

        data = await _articleService.FindAsync(id);
        MemoryCache.Set(id, data, TimeSpan.FromSeconds(10));
        Log.Info(JsonConvert.SerializeObject(data));
        return data != null ? ApiResultHelper.Success(data) : ApiResultHelper.NotFound();
    }

    /// <summary>
    /// 根据作者获取文章列表
    /// </summary>
    /// <param name="name">作者名</param>
    /// <returns></returns>
    [HttpGet, Route("getlist")]
    [ApiExplorerSettings(GroupName = nameof(ApiVersion.v1))]
    public async Task<ApiResult> GetList([FromQuery] string name)
    {
        var articles = await _articleService.QueryAsync(cj => cj.ArticleAuthor == name);
        return articles != null ? ApiResultHelper.Success(articles) : ApiResultHelper.NotFound();
    }

    /// <summary>
    /// 新增一条文章记录
    /// </summary>
    /// <param name="article">文章</param>
    /// <returns></returns>
    [HttpPost, Route("insert")]
    [ApiExplorerSettings(GroupName = nameof(ApiVersion.v1))]
    public async Task<ApiResult> Create([FromBody] Article article)
    {
        article.ArticleId = await Nanoid.Nanoid.GenerateAsync();
        article.GmtCreate = DateTime.Now;
        article.GmtModified = DateTime.Now;
        var identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
        var currentUserId = identity?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        article.CreateUserId = currentUserId;
        article.ModifiedUserId = currentUserId;
        article.IsDeleted = false;
        return ApiResultHelper.Success(await _articleService.CreateAsync(article));
    }

    /// <summary>
    /// 更新文章信息
    /// </summary>
    /// <param name="article">文章</param>
    /// <returns></returns>
    [HttpPut, Route("update")]
    [ApiExplorerSettings(GroupName = nameof(ApiVersion.v1))]
    public async Task<ApiResult> Update([FromBody] Article article)
    {
        article.GmtModified = DateTime.Now;
        var identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
        var currentUserId = identity?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        article.ModifiedUserId = currentUserId;
        return ApiResultHelper.Success(await _articleService.EditAsync(article));
    }

    /// <summary>
    /// 根据id删除文章
    /// </summary>
    /// <param name="id">id</param>
    /// <returns></returns>
    [HttpDelete, Route("delete/{id}")]
    [ApiExplorerSettings(GroupName = nameof(ApiVersion.v1))]
    public async Task<ApiResult> Delete([FromRoute] string id)
    {
        return ApiResultHelper.Success(await _articleService.DeleteAsync(id));
    }

    /// <summary>
    /// 批量插入文章
    /// </summary>
    /// <param name="articles">文章列表</param>
    /// <returns></returns>
    [HttpPost, Route("insertbluk")]
    [ApiExplorerSettings(GroupName = nameof(ApiVersion.v2))]
    public async Task<ApiResult> CreateBluk([FromBody] List<Article> articles)
    {
        foreach (var article in articles)
        {
            article.ArticleId = await Nanoid.Nanoid.GenerateAsync();
            article.GmtCreate = DateTime.Now;
            article.GmtModified = DateTime.Now;
            article.CreateUserId = "admin";
            article.ModifiedUserId = "admin";
            article.IsDeleted = false;
        }

        var bulkAsync = await _articleService.CreateBulkAsync(articles);

        return ApiResultHelper.Success(bulkAsync);
    }
}