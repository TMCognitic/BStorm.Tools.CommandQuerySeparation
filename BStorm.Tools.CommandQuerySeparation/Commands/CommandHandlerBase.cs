namespace BStorm.Tools.CommandQuerySeparation.Commands
{
    public abstract class CommandHandlerBase<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommandDefinition
    {
        ICommandResult ICommandHandler<TCommand>.Execute(TCommand command)
        {
            try
            {
                return Execute(command);
            }
            catch (Exception ex)
            {
                return ICommandResult.Failure(ex.Message, ex);
            }
        }

        protected abstract ICommandResult Execute(TCommand command);
    }
}
