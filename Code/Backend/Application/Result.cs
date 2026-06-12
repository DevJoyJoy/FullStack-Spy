namespace Backend.Application;

public record Result<T>
(
	bool IsSuccess,
	T data,
	string reason
)
{
	public static Result<T> Success(T data)
		=> new(true, data, null);
		
	public static Result<T> Fail(string reason)
		=> new(false, default, reason);
}
