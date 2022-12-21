using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Application.Interfaces.Repos
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository CustomerRepository { get; }
        //IMessageRepository MessageRepository { get; }

        Task Save();
    }
}
