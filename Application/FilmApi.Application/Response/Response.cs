namespace FilmApi.Application.Response;

public class Response<T>
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public int StatusCode { get; set; }
    public T? Data { get; set; }

    public static Response<T> Success(T? data, string? message = null, int statusCode = 200)
        => new()
        {
            IsSuccess = true,
            Data = data,
            Message = message,  
            StatusCode = statusCode
        };

    public static Response<T> Failure(string message, int statusCode = 400)
        => new()
        {
            IsSuccess = false,
            Message = message,
            StatusCode = statusCode
        };


}
