namespace BStorm.Tools.CommandQuerySeparation.Commands
{
    internal class CommandResult : ICommandResult
    {
        public bool IsSuccess
        {
            get; init;
        }

        public bool IsFailure
        {
            get
            {
                return !IsSuccess;
            }
        }

        public string? ErrorMessage
        {
            get; init;
        }

        public Exception? Exception
        {
            get; init;
        }

        internal CommandResult(bool isSuccess, string? errorMessage = null, Exception? exception = null)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            Exception = exception;
        }
    }
}
