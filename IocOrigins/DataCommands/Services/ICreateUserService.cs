using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.DataCommands.Services
{
    public interface ICreateUserService
    {
        void Create(string username);
    }
}
