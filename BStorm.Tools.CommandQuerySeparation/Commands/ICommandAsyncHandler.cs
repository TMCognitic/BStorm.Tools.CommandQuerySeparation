namespace BStorm.Tools.CommandQuerySeparation.Commands
{
    public interface ICommandAsyncHandler<TCommand>
        where TCommand : ICommandDefinition
    {
        ValueTask<ICommandResult> ExecuteAsync(TCommand command);
    }
}
