using Hermes.Application.Interfaces.Repos;
using Hermes.Domain.Entities;
using Hermes.Persistence.Interfaces.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User> , IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
    {
    }
}
}
