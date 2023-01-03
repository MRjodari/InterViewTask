using Hermes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Persistence.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Guid guid1 = Guid.NewGuid();
            Guid guid2 = Guid.NewGuid();
            Guid guid3 = Guid.NewGuid();
            Guid guid4 = Guid.NewGuid();
            Guid guid5 = Guid.NewGuid();
            Guid guid6 = Guid.NewGuid();
            Guid guid7 = Guid.NewGuid();
            Guid guid8 = Guid.NewGuid();
            Guid guid9 = Guid.NewGuid();
            Guid guid10 = Guid.NewGuid();
            Guid guid11 = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = Guid.NewGuid(),
                        UserName = "Mora",
                        DeviceIdentifier = guid1

                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        UserName = "Ali",
                        DeviceIdentifier = guid2

                    },
                    new User { Id = Guid.NewGuid(), UserName = "Mehran", DeviceIdentifier = guid3 },
                    new User { Id = Guid.NewGuid(), UserName = "Babak", DeviceIdentifier = guid4 },
                    new User { Id = Guid.NewGuid(), UserName = "Sara", DeviceIdentifier = guid5 },
                    new User { Id = Guid.NewGuid(), UserName = "Ahad", DeviceIdentifier = guid6 },
                    new User { Id = Guid.NewGuid(), UserName = "Reza", DeviceIdentifier = guid7 },
                    new User { Id = Guid.NewGuid(), UserName = "Maryam", DeviceIdentifier = guid8 },
                    new User { Id = Guid.NewGuid(), UserName = "Saeid", DeviceIdentifier = guid9 },
                    new User { Id = Guid.NewGuid(), UserName = "Saman", DeviceIdentifier = guid10 },
                    new User { Id = Guid.NewGuid(), UserName = "Aidin", DeviceIdentifier = guid11 }
                );

            modelBuilder.Entity<UserMessage>().HasData(
                   new UserMessage
                   {
                       DeviceId = guid1,
                       Content = "TestMessage",
                       Status = false

                   },
                    new UserMessage
                    {
                        DeviceId = guid2,
                        Content = "TestMessage",
                        Status = false

                    },
                    new UserMessage
                    {
                        DeviceId = guid3,
                        Content = "TestMessage",
                        Status = false

                    });
        }
    }
}
