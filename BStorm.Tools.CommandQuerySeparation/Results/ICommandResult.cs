namespace BStorm.Tools.CommandQuerySeparation.Results
{
    public interface ICommandResult
    {
        static ICommandResult Success()
        {
            return new Result(true, null, null);
        }

        static ICommandResult Failure(string errorMessage, Exception? exception = null)
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
}
