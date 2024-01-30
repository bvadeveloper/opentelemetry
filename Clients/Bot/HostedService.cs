using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Bot;

public class HostedService(MessageSender messageSender, ILogger<HostedService> logger) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        while (true)
        {
            try
            {
                var message = messageSender.Send();
                logger.LogInformation($"Message content '{message}'");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }

            using var httpClient = new HttpClient();
            while (true)
            {
                try
                {
                    var content = await httpClient.GetStringAsync("http://source.one/car", cancellationToken);
                    logger.LogInformation($"Http response '{content}'");
                }
                catch (HttpRequestException ex)
                {
                    logger.LogError(ex, ex.Message);
                }
            
                await Task.Delay(3000, cancellationToken);
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}