namespace BStorm.Tools.CommandQuerySeparation.Results
{
    public interface IResultBase
    {
        bool IsSuccess { get; }
        bool IsFailure { get; }

        string? ErrorMessage { get; }
        Exception? Exception { get; }
    }
}
