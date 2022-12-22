using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Application.Common
{
    public class CustomException : Exception
    {
        public CustomException(string message, int errorCode) : base(message)
        {
            MyMessage = message.Trim();
            ErrorCode = errorCode;
        }
        public int ErrorCode { get; set; }
        public string MyMessage { get; set; }
    }

}
