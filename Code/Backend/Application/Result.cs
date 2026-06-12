namespace Backend.Application;

public record Result<T>(
    bool isSuccess,
    string message, 
    string reason
)
{
    public static Result<T> Success( T data)
    => new()
}