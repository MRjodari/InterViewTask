using Hermes.Application.Common;
using Hermes.Application.Services.NotificationSender;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Hermes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    { 
        private readonly IPushNotificationProviderService _pushNotificationProviderService;
        private  IConfiguration _configuration ;
        public MessageController(IPushNotificationProviderService pushNotificationProviderService,
                                IConfiguration configuration)
        {
            _pushNotificationProviderService = pushNotificationProviderService;
            _configuration = configuration;

        }


        [HttpPost("send_notification")]
        public async Task<IActionResult> Post([FromQuery] MessageDto messageDto)
        {
            if(messageDto == null)
            { return NoContent(); }
            await _pushNotificationProviderService.SendToAllUserAsync(messageDto.MessageContent.ToString());
            
            return Ok();
        }
    }
}
