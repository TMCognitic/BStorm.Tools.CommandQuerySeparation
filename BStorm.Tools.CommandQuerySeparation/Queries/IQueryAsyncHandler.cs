namespace BStorm.Tools.CommandQuerySeparation.Queries
{
    public interface IQueryAsyncHandler<TQuery, TResult>
        where TQuery : IQueryDefinition<TResult>
    {
        ValueTask<IQueryResult<TResult>> Execute(TQuery query);
    }
}
