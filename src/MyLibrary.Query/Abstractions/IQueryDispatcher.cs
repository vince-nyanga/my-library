namespace MyLibrary.Query.Abstractions;

public interface IQueryDispatcher
{
    ValueTask<TQueryResult> DispatchAsync<TQueryResult>(IQuery<TQueryResult> query);
}