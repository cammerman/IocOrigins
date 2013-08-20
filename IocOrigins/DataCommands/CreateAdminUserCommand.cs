using IocOrigins.CommandInfra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.DataCommands
{
    public class CreateAdminUserCommand : ICommand
    {
        public string Username { get; set; }
    }
}
