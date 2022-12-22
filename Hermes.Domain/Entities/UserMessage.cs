using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Domain.Entities
{
    public class UserMessage
    {
        
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        //public Guid MessageId { get; set; }
    }
}
