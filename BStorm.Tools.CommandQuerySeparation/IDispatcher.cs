using BStorm.Tools.CommandQuerySeparation.Commands;
using BStorm.Tools.CommandQuerySeparation.Queries;


namespace BStorm.Tools.CommandQuerySeparation
{
    public interface IDispatcher
    {
        ICommandResult Dispatch(ICommandDefinition command);
        IQueryResult<TResult> Dispatch<TResult>(IQueryDefinition<TResult> query);
    }
}
