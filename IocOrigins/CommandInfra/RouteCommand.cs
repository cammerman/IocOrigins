using IocOrigins.Dal;
using IocOrigins.DataCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.CommandInfra
{
    public class RouteCommand
    {
        private Dictionary<Type, Func<object>> _handlerFactoryMethodsByCommandType;

        protected virtual DataManager DataMgr { get; private set; }

        public RouteCommand(DataManager dataMgr)
        {
            DataMgr = dataMgr;

            _handlerFactoryMethodsByCommandType = 
                new Dictionary<Type,Func<object>> {
                    { typeof(CreateUserCommand), () => CreateUserHandler() },
                    { typeof(PromoteUserCommand), () => PromoteUserHandler() },
                    { typeof(DeleteUserCommand), () => DeleteUserHandler() },
                };
        }

        protected CreateUserHandler CreateUserHandler()
        {
            return new CreateUserHandler(DataMgr.BeginTransaction());
        }

        protected PromoteUserHandler PromoteUserHandler()
        {
            return new PromoteUserHandler(DataMgr.BeginTransaction());
        }
        
        protected DeleteUserHandler DeleteUserHandler()
        {
            return new DeleteUserHandler(DataMgr.BeginTransaction());
        }

        public void Route<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            var create = _handlerFactoryMethodsByCommandType[typeof(TCommand)];

            var handler = create() as IHandleCommand<TCommand>;

            handler.Handle(command);
        }
    }
}
