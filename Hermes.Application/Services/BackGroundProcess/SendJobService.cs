using Hermes.Application.Services.NotificationSender;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace Hermes.Application.Services.BackGroundProcess
{
    public class SendJobService : BackgroundService, IHostedService
    {
        private Timer _timer;
        public IServiceScopeFactory _serviceScopeFactory;
        public SendJobService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var scoped = scope.ServiceProvider.GetRequiredService<IPushNotificationProviderService>();
                while (!stoppingToken.IsCancellationRequested)
                {
                    await scoped.AutoCompleteSending(CancellationToken.None);
                    Task.Delay(300000);
                }
            }
            //return Task.CompletedTask;
        }


    }
}
