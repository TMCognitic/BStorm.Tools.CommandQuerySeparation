using BStorm.Tools.CommandQuerySeparation.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BStorm.Tools.CommandQuerySeparation.Queries
{
    public interface IQueryResult<TResult> : IResultBase
    {
        static IQueryResult<TResult> Success(TResult? result)
        {
            return new QueryResult<TResult>(true, result);
        }

        static IQueryResult<TResult> Failure(string errorMessage, Exception? exception)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
                throw new ArgumentException("At least the 'errorMessage' must be set on Failure");

            return new QueryResult<TResult>(false, default, errorMessage, exception);
        }

        TResult? Result { get; }
    }
}
