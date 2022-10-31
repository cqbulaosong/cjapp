namespace CjApp.Jwt.Helper;

/// <summary>
/// 返回结果帮助类
/// </summary>
public static class ApiResultHelper
{
    /// <summary>
    /// 成功返回(带数据)
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static ApiResult Success(dynamic data)
    {
        return new ApiResult
        {
            Code = 200,
            Message = "操作成功",
            Data = data
        };
    }
    /// <summary>
    /// 未查到数据
    /// </summary>
    /// <returns></returns>
    public static ApiResult NotFound()
    {
        return new ApiResult
        {
            Code = 404,
            Message = "未查询到任何数据"
        };
    }
    /// <summary>
    /// 错误返回
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>

    public static ApiResult Error(string msg)
    {
        return new ApiResult
        {
            Code = 500,
            Message = msg,
            Data = ""
        };
    }
}