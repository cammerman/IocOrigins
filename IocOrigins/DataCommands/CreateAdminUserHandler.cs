using IocOrigins.CommandInfra;
using IocOrigins.Dal;
using IocOrigins.DataCommands.Services;
using IocOrigins.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.DataCommands
{   
    public class CreateAdminUserHandler : IHandleCommand<CreateUserCommand>
    {
        protected IDataTransaction Transaction { get; private set; }
        protected ICreateUserService Create { get; private set; }
        protected IPromoteUserService Promote { get; private set; }

        public CreateAdminUserHandler(
            IDataTransaction tx,
            ICreateUserService create,
            IPromoteUserService promote)
        {
            Transaction = tx;
            Create = create;
            Promote = promote;
        }

        public void Handle(CreateUserCommand command)
        {
            try
            {
                Create.Create(Transaction, command.Username);
                Promote.Promote(Transaction, command.Username);
            }
            catch (Exception ex)
            {
                Transaction.Cancel();
                throw new DataCommandException("Unable to create admin user from scratch.", ex);
            }

            Transaction.Commit();
        }
    }
}
