using IocOrigins.Dal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins
{
    public class ConnectionString : IConnectionString
    {
        public string Value
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["dataStore"].ConnectionString;
            }
        }
    }
}
