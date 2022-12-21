using Hermes.Application.Interfaces.Repos;
using Hermes.Persistence.Interfaces.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }
        public IUserRepository CustomerRepository => throw new NotImplementedException();

        //public IMessageRepository MessageRepository => throw new NotImplementedException();

        public async void Dispose()
        {
            await context.DisposeAsync();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
