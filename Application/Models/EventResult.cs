
namespace Application.Models;

public class EventResult
{
    public bool Success { get; set; }

    public string? Error { get; set; }
}


public class EventResult<T> : RepositoryResult
{
    public T? Result { get; set; }

}