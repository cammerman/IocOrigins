using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.CommandInfra
{
    public interface IRouteCommand
    {
        void Route<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}
