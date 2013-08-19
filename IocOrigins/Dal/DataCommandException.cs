using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins
{
    public class DataCommandException : Exception
    {
        public DataCommandException() { }
        
        public DataCommandException(string message)
            :base(message)
        {
        }

        public DataCommandException(string message, Exception innerException)
            :base(message, innerException)
        {
        }
    }
}
