using BStorm.Tools.CommandQuerySeparation.Results;

namespace BStorm.Tools.CommandQuerySeparation.Queries
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQueryDefinition<TResult>
    {
        IResult<TResult> Execute(TQuery query);
    }
}
