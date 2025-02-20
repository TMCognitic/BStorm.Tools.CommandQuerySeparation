namespace BStorm.Tools.CommandQuerySeparation.Results
{
    internal class Result : IResult
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

        public Exception? Exception
        {
            get;
        }

        internal Result(bool isSuccess, string? errorMessage = null, Exception? exception = null)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            Exception = exception;
        }
    }

    internal class Result<TResult> : IResult<TResult>
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

        public Exception? Exception
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

        internal Result(bool isSuccess, TResult? content, string? errorMessage = null, Exception? exception = null)
        {
            IsSuccess = isSuccess;
            _content = content;
            ErrorMessage = errorMessage;
            Exception = exception;
        }
    }
}
