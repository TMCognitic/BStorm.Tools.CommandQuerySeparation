using BStorm.Tools.CommandQuerySeparation.Commands;
using BStorm.Tools.CommandQuerySeparation.Queries;
using BStorm.Tools.CommandQuerySeparation.Results;


namespace BStorm.Tools.CommandQuerySeparation.Dispatching
{
    public interface IDispatcher
    {
        ICommandResult Dispatch(ICommandDefinition command);
        ValueTask<ICommandResult> DispatchAsync(ICommandDefinition command);
        IQueryResult<TResult> Dispatch<TResult>(IQueryDefinition<TResult> query);
        ValueTask<IQueryResult<TResult>> DispatchAsync<TResult>(IQueryDefinition<TResult> query);
    }
}
