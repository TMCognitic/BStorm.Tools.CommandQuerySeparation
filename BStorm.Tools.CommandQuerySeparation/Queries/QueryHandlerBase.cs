using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BStorm.Tools.CommandQuerySeparation.Queries
{
    public abstract class QueryHandlerBase<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQueryDefinition<TResult>
    {
        IQueryResult<TResult> IQueryHandler<TQuery, TResult>.Execute(TQuery query)
        {
            try
            {
                return Execute(query);
            }
            catch (Exception ex)
            {
                return IQueryResult<TResult>.Failure(ex.Message, ex);
            }
        }

        protected abstract IQueryResult<TResult> Execute(TQuery query);
    }
}
