namespace BStorm.Tools.CommandQuerySeparation.Queries
{
    internal class QueryResult<TResult> : IQueryResult<TResult>
    {
        private readonly TResult? _result;

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

        public TResult? Result
        {
            get 
            {
                if (IsFailure)
                    throw new InvalidOperationException();

                return _result;
            }
        }

        internal QueryResult(bool isSuccess, TResult? result, string? errorMessage = null, Exception? exception = null)
        {
            IsSuccess = isSuccess;
            _result = result;
            ErrorMessage = errorMessage;
            Exception = exception;
        }
    }
}
