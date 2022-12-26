using Hermes.Worker;
using Hermes.Worker.BackGroundServices.QueuedBackgroundTasks;
using Hermes.Worker.BackGroundServices.TimedBackgroundTasks;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<TimedHostedService>();

        services.AddHostedService<Worker>();
        services.AddScoped<IScopedProcessingService, ScopedProcessingService>();

        services.AddSingleton<MonitorLoop>();
        services.AddHostedService<QueuedHostedService>(
        services.AddSingleton<IBackgroundTaskQueue>(ctx =>
                                                          {
                                                              if (!int.TryParse(HostContext.Configuration["QueueCapacity"], out var queueCapacity))
                                                                  queueCapacity = 100;
                                                              return new BackgroundTaskQueue(queueCapacity);
                                                          });
    })
    .Build();
var monitorLoop = host.Services.GetRequiredService<MonitorLoop>();
monitorLoop.StartMonitorLoop();
await host.RunAsync();
