using BStorm.Tools.CommandQuerySeparation.Queries;

namespace BStorm.Tools.CommandQuerySeparation.Results
{
    public interface IResult : IResultBase
    {
        static IResult Success()
        {
            return new Result(true, null, null);
        }

        static IResult Failure(string errorMessage, Exception? exception = null)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
                throw new ArgumentException("At least the 'errorMessage' must be set on Failure");

            return new Result(false, errorMessage, exception);
        }
    }

    public interface IResult<TResult> : IResultBase
    {
        static IResult<TResult> Success(TResult? result)
        {
            return new Result<TResult>(true, result);
        }

        static IResult<TResult> Failure(string errorMessage, Exception? exception)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
                throw new ArgumentException("At least the 'errorMessage' must be set on Failure");

            return new Result<TResult>(false, default, errorMessage, exception);
        }

        TResult? Content { get; }
    }
}
