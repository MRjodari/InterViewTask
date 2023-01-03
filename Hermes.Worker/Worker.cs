using Hermes.Worker.BackGroundServices.TimedBackgroundTasks;

namespace Hermes.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        //ConsumeScopedServiceHostedService 
        public Worker(IServiceProvider services, 
                                ILogger<Worker> logger)
        {
            Services = services;
            _logger = logger;
        }
        public IServiceProvider Services { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await DoWork(stoppingToken);
                await Task.Delay(1000, stoppingToken);
            }
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Consume Scoped Service Hosted Service is working.");

            using (var scope = Services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<IScopedProcessingService>();

                await scopedProcessingService.DoWork(stoppingToken);
            }
        }
        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Consume Scoped Service Hosted Service is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}