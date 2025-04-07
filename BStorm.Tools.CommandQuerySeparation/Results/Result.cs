namespace BStorm.Tools.CommandQuerySeparation.Results
{
    internal class Result : ICommandResult
    {
        public bool IsSuccess
        {
            get;
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
            get;
        }

        public string? ExceptionMessage
        {
            get;
        }

        public string? ExceptionType
        {
            get;
        }

        internal Result(bool isSuccess, string? errorMessage = null, Exception? exception = null)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            ExceptionMessage = exception?.Message;
            ExceptionType = exception?.GetType().FullName;
        }
    }

    internal class Result<TResult> : IQueryResult<TResult>
    {
        private readonly TResult? _content;

        public bool IsSuccess
        {
            get;
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
            get;
        }

        public TResult? Content
        {
            get
            {
                if (IsFailure)
                    throw new InvalidOperationException();

                return _content;
            }
        }

        public string? ExceptionMessage
        {
            get;
        }

        public string? ExceptionType
        {
            get;
        }

        internal Result(bool isSuccess, TResult? content, string? errorMessage = null, Exception? exception = null)
        {
            IsSuccess = isSuccess;
            _content = content;
            ErrorMessage = errorMessage;
            ExceptionMessage = exception?.Message;
            ExceptionType = exception?.GetType().FullName;
        }
    }
}
