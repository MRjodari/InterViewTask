using Hermes.Application.Interfaces.Repos;
using Hermes.Domain.Entities;
using Hermes.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Persistence.Repositories
{
    public class UserMessageRepository : GenericRepository<UserMessage>, IUserMessageRepository
    {
        public UserMessageRepository(AppDbContext context) : base(context)
        {
        }
    }
}
