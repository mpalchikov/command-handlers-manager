using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CHM.Commands
{
    abstract class ManagedCommandHandler<TRequest> : IRequestHandler<TRequest> where TRequest : IRequest
    {
        private readonly ICommandsHandlerManager _manager;
        protected readonly ILogger _logger;

        public ManagedCommandHandler(ILogger logger, ICommandsHandlerManager manager)
        {
            _manager = manager;
            _logger = logger;
        }

        public async Task<Unit> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var handlerType = GetType();
            if (_manager.IsExecuted(handlerType))
            {
                _logger.LogInformation($"Ignored: {handlerType}. Is executing");

                return await Unit.Task;
            }

            _manager.Start(handlerType);
            _logger.LogInformation($"Started: {handlerType}");

            try
            {
                await HandleCommand();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                _manager.Finish(handlerType);
                _logger.LogInformation($"Finished: {handlerType}");
            }

            return await Unit.Task;
        }

        public abstract Task HandleCommand();
    }
}
