namespace MyLibrary.Query.Abstractions;

public interface IQueryHandler<in TQuery, TQueryResult> where TQuery : IQuery<TQueryResult>
{
    ValueTask<TQueryResult> HandleAsync(TQuery query);
}