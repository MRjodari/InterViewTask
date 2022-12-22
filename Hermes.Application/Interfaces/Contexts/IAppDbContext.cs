using Hermes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Application.Interfaces.Contexts
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; set; }
        //DbSet<Message> Messages { get; set; }
        DbSet<UserMessage> UserMessages { get; set; }
    }
}
