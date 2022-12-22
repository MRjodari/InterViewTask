using Hermes.Application.Interfaces.Repos;
using Hermes.Application.Services.NotificationSender;
using Hermes.Tests.Mocks.UserMock;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Hermes.Tests.NotificationTest
{
    public class PushNotificationProviderServiceTest
    {


        private readonly Mock<IUnitOfWork> _unitOfWork;

        public PushNotificationProviderServiceTest()
        {
            _unitOfWork= MockUnitOfWork.GetUnitOfWork();
        }

       

        [Fact]
        public async Task Select_SholdBeRemainedUser()
        {
            // Arrage
            var AllUsers = await _unitOfWork.Object.UserRepository.GetAll();
            var AllSentMessageUsers = await _unitOfWork.Object.UserMessageRepository.GetAll();
            // Act
            var service = new PushNotificationProviderService(_unitOfWork.Object);
            var RemainedUser = service.GetRemainedUser();
            // Assert
            RemainedUser.Length.ShouldBe(2);
            
        }
    }
}
