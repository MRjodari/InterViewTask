using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Domain.Entities
{
    public class UserMessage
    {
        
        public Guid DeviceId { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
    }
}
