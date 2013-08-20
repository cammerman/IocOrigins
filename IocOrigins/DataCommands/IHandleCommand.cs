using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.DataCommands
{
    public interface IHandleCommand<TCommand>
    {
        void DoWork(TCommand param);
    }
}
