using System.Security.Claims;
using CjApp.Enum;
using CjApp.Helper;
using CjApp.Helper.Helper;
using CjApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CjApp.Controllers;

/// <summary>
/// 通用controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
[ApiExplorerSettings(GroupName = nameof(ApiVersion.v1))]
public class HelloController: ControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
 
    /// <summary>
    /// HelloController
    /// </summary>
    /// <param name="httpContextAccessor"></param>
    public HelloController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    /// <summary>
    /// 首页
    /// </summary>
    /// <returns></returns>
    [HttpGet("index")]
    public string Index()
    {
        var ip = GetIp();
        return $"your ip: {ip}";
    }
    /// <summary>
    /// 获取农历日期
    /// </summary>
    /// <returns></returns>
    [HttpGet("today")]
    public string Today()
    {
        var today = DateTime.Today;
        return ChinaDate.GetChinaDate(today);
    }
    
    /// <summary>
    /// 获取客户端IP
    /// </summary>
    /// <returns></returns>
    private string GetIp()
    {
        return HttpContext.Connection.RemoteIpAddress != null ? HttpContext.Connection.RemoteIpAddress.ToString() : "";
    }
    
    /// <summary>
    /// 获取当前用户信息
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetCurrentUser")]
    public ApiResult GetCurrentUser()
    {
        var identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
        var user = new SystemUser
        {
            FullName = identity?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value,
            SystemUserId = identity?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
            Phone = identity?.Claims.FirstOrDefault(x => x.Type == "Phone")?.Value,
            Email = identity?.Claims.FirstOrDefault(x => x.Type == "Email")?.Value
        };
        return ApiResultHelper.Success(user);
    }
}