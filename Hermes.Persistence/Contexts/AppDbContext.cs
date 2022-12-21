using Hermes.Application.Interfaces.Contexts;
using Hermes.Application.Values;
using Hermes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Persistence.Interfaces.Contexts
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        //public DbSet<Message> Messages { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(p => p.DeviceIdentifier).IsRequired();

            //modelBuilder.Entity<UserMessage>().HasQueryFilter(p => !p.MessageId);
        }
    }
}
