﻿using BStorm.Tools.CommandQuerySeparation.Results;

namespace BStorm.Tools.CommandQuerySeparation.Commands
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommandDefinition
    {
        ICqsResult Execute(TCommand command);
    }
}
