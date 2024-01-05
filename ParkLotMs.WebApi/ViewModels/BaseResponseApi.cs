using System.Text.Json.Serialization;

namespace ParkLotMs.WebApi.ViewModels;

public class BaseResponseApi<T> where T : class
{
    public BaseResponseApi()
    {
        IsSuccess = true;
        StatusCode = 200;
        Message = "Ok";
        InnerMessage = null;
        Path = null;
        Payload = null;
        Method = null;
    }

    /// <summary>
    /// Default value is true.
    /// </summary>
    /// <value></value>
    [JsonPropertyName("isSuccess")]
    public bool IsSuccess { get; set; }

    /// <summary>
    /// Default value is 200OK.
    /// </summary>
    /// <value></value>
    [JsonPropertyName("statusCode")]
    public int StatusCode { get; set; }

    /// <summary>
    /// Default value is "Ok".
    /// </summary>
    /// <value></value>
    [JsonPropertyName("message")]
    public string Message { get; set; }

    /// <summary>
    /// Default value is null.
    /// </summary>
    /// <value></value>
    [JsonPropertyName("innerMessage")]
    public string InnerMessage { get; set; }

    /// <summary>
    /// Default value is null.
    /// </summary>
    /// <value></value>
    [JsonPropertyName("path")]
    public string Path { get; set; }

    /// <summary>
    /// Default value is null.
    /// </summary>
    /// <value></value>
    [JsonPropertyName("method")]
    public string Method { get; set; }

    /// <summary>
    /// Default value is null.
    /// </summary>
    /// <value></value>
    [JsonPropertyName("payload")]
    public T Payload { get; set; }
}
