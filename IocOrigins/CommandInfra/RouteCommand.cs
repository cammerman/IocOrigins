using Autofac;
using IocOrigins.Dal;
using IocOrigins.DataCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.CommandInfra
{
    public class RouteCommand : IRouteCommand
    {
        protected IContainer Container { get; private set; }

        public RouteCommand(IContainer container)
        {
            Container = container;
        }

        public void Route<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            var handler = Container.Resolve<IHandleCommand<TCommand>>();

            handler.Handle(command);
        }
    }
}
