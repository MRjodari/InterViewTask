using Hermes.Application.Interfaces.Repos;
using Hermes.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Tests.Mocks.UserMock
{
    public static class MockUserMessageRepository
    {
        public static Mock<IUserMessageRepository> GetUserMessageRepository()
        {
            Guid guid1 = Guid.NewGuid();
            Guid guid2 = Guid.NewGuid();
            Guid guid3 = Guid.NewGuid();
            Guid guid4 = Guid.NewGuid();
            Guid guid5 = Guid.NewGuid();

            var UserMessages = new List<UserMessage>
            {
                    new UserMessage { Id = Guid.NewGuid(), UserId = Guid.NewGuid()},
                    new UserMessage { Id = Guid.NewGuid(), UserId = Guid.NewGuid()},
                    new UserMessage { Id = Guid.NewGuid(), UserId = Guid.NewGuid()},
                    
            };
            var mockRepo = new Mock<IUserMessageRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(UserMessages);
            mockRepo.Setup(r => r.Add(It.IsAny<UserMessage>())).ReturnsAsync((UserMessage userMessage) =>
            {
                UserMessages.Add(userMessage);
                return userMessage;
            });
            mockRepo.Setup(r => r.Delete(It.IsAny<UserMessage>())).Returns((UserMessage userMessage) =>
            {
                return Task.FromResult(UserMessages.Remove(userMessage));

            });

            return mockRepo;

        }
    }
}
