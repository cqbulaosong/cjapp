using System.Text;

namespace CjApp.Helper.Helper;

public static class HttpHelper
{
    /// <summary>
    /// 发起POST同步请求
    /// </summary>
    /// <param name="url"></param>
    /// <param name="postData"></param>
    /// <param name="contentType">application/xml、application/json、application/text、application/x-www-form-urlencoded</param>
    /// <param name="headers">填充消息头</param>
    /// <returns></returns>
    public static string Post(string url, string postData = null, string contentType = "application/json", Dictionary<string, string> headers = null)
    {
        postData ??= "";
        using var client = new HttpClient();
        if (headers != null)
        {
            foreach (var header in headers)
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
        }

        using HttpContent httpContent = new StringContent(postData, Encoding.UTF8);
        if (contentType != null)
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);

        var response = client.PostAsync(url, httpContent).Result;
        response.EnsureSuccessStatusCode();
        return response.Content.ReadAsStringAsync().Result;
    }

    /// <summary>
    /// 发起POST异步请求
    /// </summary>
    /// <param name="url"></param>
    /// <param name="postData"></param>
    /// <param name="contentType">application/xml、application/json、application/text、application/x-www-form-urlencoded</param>
    /// <param name="timeOut"></param>
    /// <param name="headers">填充消息头</param>
    /// <returns></returns>
    public static async Task<string> PostAsync(string url, string postData = null, string contentType = "application/json", int timeOut = 30, Dictionary<string, string> headers = null)
    {
        postData ??= "";
        using var client = new HttpClient();
        client.Timeout = new TimeSpan(0, 0, timeOut);
        if (headers != null)
        {
            foreach (var header in headers)
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
        }

        using HttpContent httpContent = new StringContent(postData, Encoding.UTF8);
        if (contentType != null)
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);

        var response = await client.PostAsync(url, httpContent);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    /// <summary>
    /// 发起GET同步请求
    /// </summary>
    /// <param name="url"></param>
    /// <param name="headers"></param>
    /// <param name="contentType"></param>
    /// <returns></returns>
    public static string Get(string url, string contentType = "application/json", Dictionary<string, string> headers = null)
    {
        using var client = new HttpClient();
        if (contentType != null)
            client.DefaultRequestHeaders.Add("ContentType", contentType);
        if (headers != null)
        {
            foreach (var header in headers)
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
        }

        var response = client.GetAsync(url).Result;
        response.EnsureSuccessStatusCode();
        return response.Content.ReadAsStringAsync().Result;
    }

    /// <summary>
    /// 发起GET异步请求
    /// </summary>
    /// <param name="url"></param>
    /// <param name="headers"></param>
    /// <param name="contentType"></param>
    /// <returns></returns>
    public static async Task<string> GetAsync(string url, string contentType = "application/json", Dictionary<string, string> headers = null)
    {
        using var client = new HttpClient();
        if (contentType != null)
            client.DefaultRequestHeaders.Add("ContentType", contentType);
        if (headers != null)
        {
            foreach (var header in headers)
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
        }

        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}