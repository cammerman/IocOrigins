using IocOrigins.CommandInfra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.DataCommands
{
    public class CreateUserCommand : ICommand
    {
        public string Username { get; set; }
    }
}
