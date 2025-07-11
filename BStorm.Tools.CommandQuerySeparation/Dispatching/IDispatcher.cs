using BStorm.Tools.CommandQuerySeparation.Commands;
using BStorm.Tools.CommandQuerySeparation.Queries;
using BStorm.Tools.CommandQuerySeparation.Results;


namespace BStorm.Tools.CommandQuerySeparation.Dispatching
{
    public interface IDispatcher
    {
        ICqsResult Dispatch(ICommandDefinition command);
        ValueTask<ICqsResult> DispatchAsync(ICommandDefinition command);
        ICqsResult<TResult> Dispatch<TResult>(IQueryDefinition<TResult> query);
        ValueTask<ICqsResult<TResult>> DispatchAsync<TResult>(IQueryDefinition<TResult> query);
    }
}
