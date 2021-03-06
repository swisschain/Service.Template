﻿using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using ServiceName.Common.Domain.AppFeatureExample;

namespace ServiceName.Worker.Messaging.Consumers
{
    // TODO: Just an example
    public class ExecuteSomethingConsumer : IConsumer<ExecuteSomething>
    {
        private readonly ILogger<ExecuteSomethingConsumer> _logger;

        public ExecuteSomethingConsumer(ILogger<ExecuteSomethingConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ExecuteSomething> context)
        {
            var command = context.Message;

            _logger.LogInformation("'Execute something' command has been processed {@context}", command);

            await Task.CompletedTask;
        }
    }
}
