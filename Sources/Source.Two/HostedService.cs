using Microsoft.Extensions.Hosting;

namespace Source.Two;

public class HostedService(MessageReceiver messageReceiver) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        messageReceiver.StartConsumer();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}