using Hermes.Application.Interfaces.Repos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Tests.Mocks.UserMock
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockUserRepo = MockRepository.GetRepository();
            //var mockUserMessageRepo = MockRepository.GetUserMessageRepository();

            mockUow.Setup(r => r.UserRepository).Returns(mockUserRepo.Object.UserRepository);
            mockUow.Setup(r => r.UserMessageRepository).Returns(mockUserRepo.Object.UserMessageRepository);

            return mockUow;
        }
    }
}
