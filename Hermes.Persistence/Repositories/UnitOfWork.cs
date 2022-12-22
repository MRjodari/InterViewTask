using Hermes.Application.Interfaces.Repos;
using Hermes.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
        private IUserRepository _userRepository;
        private IUserMessageRepository _userMessageRepository;
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
        public IUserMessageRepository UserMessageRepository => _userMessageRepository ??= new UserMessageRepository(_context);
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        //public IMessageRepository MessageRepository => throw new NotImplementedException();

        public void Dispose()
        {
             _context.DisposeAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
