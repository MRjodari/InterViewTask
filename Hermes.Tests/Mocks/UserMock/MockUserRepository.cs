
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
    public static class MockUserRepository
    {
        public static Mock<IUserRepository> GetUserRepository()
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
                    new User { Id = Guid.NewGuid(), UserName = "Maryam", DeviceIdentifier = guid4 }
            };

            var mockRepo = new Mock<IUserRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(Users);
            mockRepo.Setup(r => r.Add(It.IsAny<User>())).ReturnsAsync((User user) =>
            {
                Users.Add(user);
                return user;
            });
            mockRepo.Setup(r => r.Delete(It.IsAny<User>())).Returns((User user) =>
            {
                return Task.FromResult(Users.Remove(user));

            });

            return mockRepo;

        }
    }
}
