using BStorm.Tools.CommandQuerySeparation.Results;

namespace BStorm.Tools.CommandQuerySeparation.Commands
{
    public interface IAsyncCommandHandler<TCommand>
        where TCommand : ICommandDefinition
    {
        ValueTask<ICqsResult> ExecuteAsync(TCommand command);
    }
}
