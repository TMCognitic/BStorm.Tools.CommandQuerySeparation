namespace BStorm.Tools.CommandQuerySeparation.Results
{
    public interface IQueryResult<TResult>
    {
        static IQueryResult<TResult> Success(TResult? result)
        {
            return new Result<TResult>(true, result);
        }

        static IQueryResult<TResult> Failure(string errorMessage, Exception? exception)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
                throw new ArgumentException("At least the 'errorMessage' must be set on Failure");

            return new Result<TResult>(false, default, errorMessage, exception);
        }

        bool IsSuccess { get; }
        bool IsFailure { get; }

        string? ErrorMessage { get; }
        string? ExceptionMessage { get; }
        string? ExceptionType { get; }

        TResult? Content { get; }
    }
}
