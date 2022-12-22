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
    public static class MockRepository
    {
        public static Mock<IUnitOfWork> GetRepository()
        {
            Guid guid1 = Guid.NewGuid();
            Guid guid2 = Guid.NewGuid();
            Guid guid3 = Guid.NewGuid();
            Guid guid4 = Guid.NewGuid();
            Guid guid5 = Guid.NewGuid();

            var Users = new List<User>
            {
                    new User { Id = Guid.NewGuid(), UserName = "Mehran", DeviceIdentifier = guid1 },
                    new User { Id = Guid.NewGuid(), UserName = "Babak", DeviceIdentifier = guid2 },
                    new User { Id = Guid.NewGuid(), UserName = "Sara", DeviceIdentifier = guid3 },
                    new User { Id = Guid.NewGuid(), UserName = "Ahad", DeviceIdentifier = guid4 },
                    new User { Id = Guid.NewGuid(), UserName = "Maryam", DeviceIdentifier = guid5 }
            };

            var UserMessages = new List<UserMessage>
            {
                    new UserMessage { Id = Guid.NewGuid(), UserId = guid1},
                    new UserMessage { Id = Guid.NewGuid(), UserId = guid2},
                    new UserMessage { Id = Guid.NewGuid(), UserId = guid3},

            };


            var mockRepo = new Mock<IUnitOfWork>();

            mockRepo.Setup(r => r.UserRepository.GetAll()).ReturnsAsync(Users);
            mockRepo.Setup(r => r.UserRepository.Add(It.IsAny<User>())).ReturnsAsync((User user) =>
            {
                Users.Add(user);
                return user;
            });
            mockRepo.Setup(r => r.UserRepository.Delete(It.IsAny<User>())).Returns((User user) =>
            {
                return Task.FromResult(Users.Remove(user));

            });


            mockRepo.Setup(r => r.UserMessageRepository.GetAll()).ReturnsAsync(UserMessages);
            mockRepo.Setup(r => r.UserMessageRepository.Add(It.IsAny<UserMessage>())).ReturnsAsync((UserMessage userMessage) =>
            {
                UserMessages.Add(userMessage);
                return userMessage;
            });
            mockRepo.Setup(r => r.UserMessageRepository.Delete(It.IsAny<UserMessage>())).Returns((UserMessage userMessage) =>
            {
                return Task.FromResult(UserMessages.Remove(userMessage));

            });

            

            return mockRepo;

        }
        
    }
}
