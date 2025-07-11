namespace BStorm.Tools.CommandQuerySeparation.Results
{
    public interface ICqsResult
    {
        static ICqsResult Success()
        {
            return new Result(true, null, null);
        }

        static ICqsResult Failure(string errorMessage, Exception? exception = null)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
                throw new ArgumentException("At least the 'errorMessage' must be set on Failure");

            return new Result(false, errorMessage, exception);
        }

        bool IsSuccess { get; }
        bool IsFailure { get; }

        string? ErrorMessage { get; }
        string? ExceptionMessage { get; }
        string? ExceptionType { get; }
    }

    public interface ICqsResult<TResult>
    {
        static ICqsResult<TResult> Success(TResult? result)
        {
            return new Result<TResult>(true, result);
        }

        static ICqsResult<TResult> Failure(string errorMessage, Exception? exception)
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
