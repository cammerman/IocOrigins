﻿using IocOrigins.CommandInfra;
using IocOrigins.Dal;
using IocOrigins.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.DataCommands
{
    public class PromoteUserHandler : IHandleCommand<PromoteUserCommand>
    {
        protected IDataTransaction Transaction { get; private set; }

        public PromoteUserHandler(IDataTransaction tx)
        {
            Transaction = tx;
        }

        public void Handle(PromoteUserCommand command)
        {
            var userToPromote =
                Transaction.Find<User>(user => user.Name.ToUpper() == command.Username.ToUpper())
                    .SingleOrDefault();

            if (userToPromote == null)
            {
                Transaction.Cancel();
                throw new DataCommandException("User doesn't exist.");
            }

            Console.WriteLine("Promoting user {0} to admin.", command.Username);
            userToPromote.IsAdmin = true;

            Transaction.Commit();
        }
    }
}
