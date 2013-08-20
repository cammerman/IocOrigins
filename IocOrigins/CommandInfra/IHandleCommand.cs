using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.CommandInfra
{
    public interface IHandleCommand<TCommand>
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
