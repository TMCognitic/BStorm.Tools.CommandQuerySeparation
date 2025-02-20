using BStorm.Tools.CommandQuerySeparation.Results;

namespace BStorm.Tools.CommandQuerySeparation.Commands
{
    public interface ICommandAsyncHandler<TCommand>
        where TCommand : ICommandDefinition
    {
        ValueTask<IResult> ExecuteAsync(TCommand command);
    }
}
