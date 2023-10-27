namespace MyLibrary.Query.Abstractions;

public interface IQueryDispatcher
{
    ValueTask<TQueryResult> DispatchAsync<TQuery, TQueryResult>(TQuery query) where TQuery : IQuery<TQueryResult>;
}