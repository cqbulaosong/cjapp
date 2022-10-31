namespace CjApp.Jwt.Helper;

/// <summary>
/// 返回结果结构
/// </summary>
public class ApiResult
{
    /// <summary>
    /// code
    /// </summary>
    public int Code { get; set; }
    /// <summary>
    /// 信息
    /// </summary>
    public string Message { get; set; }
    /// <summary>
    /// 数据
    /// </summary>
    public dynamic Data { get; set; }
}