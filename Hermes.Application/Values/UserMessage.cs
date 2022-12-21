using Hermes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Application.Values
{
    public class UserMessage
    {
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        public virtual Message Message { get; set; }
        public Guid MessageId { get; set; }
    }
}
