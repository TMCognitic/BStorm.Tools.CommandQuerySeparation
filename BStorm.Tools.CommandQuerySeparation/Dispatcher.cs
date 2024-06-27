using BStorm.Tools.CommandQuerySeparation.Commands;
using BStorm.Tools.CommandQuerySeparation.Queries;

namespace BStorm.Tools.CommandQuerySeparation
{
    public class Dispatcher : IDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public Dispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICommandResult Dispatch(ICommandDefinition command)
        {
            Type commandHandlerType = typeof(ICommandHandler<>);
            Type concreteCommandHandlerType = commandHandlerType.MakeGenericType(command.GetType());

            dynamic? handler = _serviceProvider.GetService(concreteCommandHandlerType);

            if (handler is null)
            {
                throw new InvalidOperationException($"the type {concreteCommandHandlerType.FullName} is'nt registered");
            }

            return Convert.ChangeType(handler, concreteCommandHandlerType).Execute((dynamic)command);
        }

        public IQueryResult<TResult> Dispatch<TResult>(IQueryDefinition<TResult> query)
        {
            Type queryHandlerType = typeof(IQueryHandler<,>);
            Type concreteQueryHandlerType = queryHandlerType.MakeGenericType(query.GetType(), typeof(TResult));

            dynamic? handler = _serviceProvider.GetService(concreteQueryHandlerType);

            if (handler is null)
            {
                throw new InvalidOperationException($"the type {concreteQueryHandlerType.FullName} is'nt registered");
            }

            return Convert.ChangeType(handler, concreteQueryHandlerType).Execute((dynamic)query);
        }
    }
}
