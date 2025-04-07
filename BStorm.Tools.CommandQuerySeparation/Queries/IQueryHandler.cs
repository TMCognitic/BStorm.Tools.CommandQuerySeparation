using BStorm.Tools.CommandQuerySeparation.Results;

namespace BStorm.Tools.CommandQuerySeparation.Queries
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQueryDefinition<TResult>
    {
        IQueryResult<TResult> Execute(TQuery query);
    }
}
