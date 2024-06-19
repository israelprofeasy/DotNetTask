namespace DotNetTask.Data.DTOs;

public class ResponseDTO<T>  where T : class
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
}