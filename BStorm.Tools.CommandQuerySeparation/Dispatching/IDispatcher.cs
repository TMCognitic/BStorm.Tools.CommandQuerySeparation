using BStorm.Tools.CommandQuerySeparation.Commands;
using BStorm.Tools.CommandQuerySeparation.Queries;
using BStorm.Tools.CommandQuerySeparation.Results;


namespace BStorm.Tools.CommandQuerySeparation.Dispatching
{
    public interface IDispatcher
    {
        IResult Dispatch(ICommandDefinition command);
        IResult<TResult> Dispatch<TResult>(IQueryDefinition<TResult> query);
    }
}
