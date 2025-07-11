using BStorm.Tools.CommandQuerySeparation.Results;

namespace BStorm.Tools.CommandQuerySeparation.Queries
{
    public interface IAsyncQueryHandler<TQuery, TResult>
        where TQuery : IQueryDefinition<TResult>
    {
        ValueTask<ICqsResult<TResult>> ExecuteAsync(TQuery query);
    }
}
