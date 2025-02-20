using BStorm.Tools.CommandQuerySeparation.Commands;
using BStorm.Tools.CommandQuerySeparation.Queries;
using BStorm.Tools.CommandQuerySeparation.Results;

namespace BStorm.Tools.CommandQuerySeparation.Dispatching
{
    public class Dispatcher : IDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public Dispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IResult Dispatch(ICommandDefinition command)
        {
            Type commandHandlerType = typeof(ICommandHandler<>);
            Type concreteCommandHandlerType = commandHandlerType.MakeGenericType(command.GetType());

            dynamic? handler = _serviceProvider.GetService(concreteCommandHandlerType);

            if (handler is null)
            {
                throw new InvalidOperationException($"the type {concreteCommandHandlerType.FullName} is'nt registered");
            }

            return handler.Execute((dynamic)command);
        }

        public async ValueTask<IResult> DispatchAsync(ICommandDefinition command)
        {
            Type commandHandlerType = typeof(ICommandAsyncHandler<>);
            Type concreteCommandHandlerType = commandHandlerType.MakeGenericType(command.GetType());

            dynamic? handler = _serviceProvider.GetService(concreteCommandHandlerType);

            if (handler is null)
            {
                throw new InvalidOperationException($"the type {concreteCommandHandlerType.FullName} is'nt registered");
            }

            return await handler.ExecuteAsync((dynamic)command);
        }

        public IResult<TResult> Dispatch<TResult>(IQueryDefinition<TResult> query)
        {
            Type queryHandlerType = typeof(IQueryHandler<,>);
            Type concreteQueryHandlerType = queryHandlerType.MakeGenericType(query.GetType(), typeof(TResult));

            dynamic? handler = _serviceProvider.GetService(concreteQueryHandlerType);

            if (handler is null)
            {
                throw new InvalidOperationException($"the type {concreteQueryHandlerType.FullName} is'nt registered");
            }

            return handler.Execute((dynamic)query);
        }

        public async ValueTask<IResult<TResult>> DispatchAsync<TResult>(IQueryDefinition<TResult> query)
        {
            Type queryHandlerType = typeof(IQueryAsyncHandler<,>);
            Type concreteQueryHandlerType = queryHandlerType.MakeGenericType(query.GetType(), typeof(TResult));

            dynamic? handler = _serviceProvider.GetService(concreteQueryHandlerType);

            if (handler is null)
            {
                throw new InvalidOperationException($"the type {concreteQueryHandlerType.FullName} is'nt registered");
            }

            return await handler.ExecuteAsync((dynamic)query);
        }
    }
}
