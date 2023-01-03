using Hermes.Application.Services.NotificationSender;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Application.Services.BackGroundProcess
{
    public class WorkerService : BackgroundService
    {
        private const int generalDelay = 1 * 300 * 1000; // 5 minute
        private  readonly IPushNotificationProviderService _pushNotificationProviderService;
        public WorkerService(IPushNotificationProviderService pushNotificationProviderService)
        {
            _pushNotificationProviderService = pushNotificationProviderService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(generalDelay, stoppingToken);
                await DoBackupAsync(Get_pushNotificationProviderService());
            }
        }

        private  IPushNotificationProviderService Get_pushNotificationProviderService()
        {
            return _pushNotificationProviderService;
        }

        private static async Task DoBackupAsync(IPushNotificationProviderService _pushNotificationProviderService)
        {
            // here i can write logic code
            await _pushNotificationProviderService.AutoCompleteSending(CancellationToken.None);


            //return Task.FromResult("Done");
        }
    }
}
