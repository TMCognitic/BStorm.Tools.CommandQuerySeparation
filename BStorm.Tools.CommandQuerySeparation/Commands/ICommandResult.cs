namespace BStorm.Tools.CommandQuerySeparation.Commands
{
    public interface ICommandResult : IResultBase
    {
        static ICommandResult Success()
        {
            return new CommandResult(true, null, null);
        }

        static ICommandResult Failure(string errorMessage, Exception? exception = null)
        {
            if(string.IsNullOrWhiteSpace(errorMessage))
                throw new ArgumentException("At least the 'errorMessage' must be set on Failure");

            return new CommandResult(false, errorMessage, exception);
        }        
    }
}
