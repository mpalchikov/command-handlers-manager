using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CHM.Commands
{
    class ProductPublishCommandHandler : ManagedCommandHandler<ProductPublishCommand>
    {
        public ProductPublishCommandHandler(ILogger<ProductPublishCommandHandler> logger, ICommandsHandlerManager manager) : base(logger, manager)
        {
        }

        public override Task HandleCommand()
        {
            _logger.LogInformation($"Handling command: {typeof(ProductPublishCommand)}");
            Thread.Sleep(10000);
            return Task.CompletedTask;
        }
    }
}
