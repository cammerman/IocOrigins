﻿using IocOrigins.Dal;
using IocOrigins.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.DataCommands
{
    public class DeleteUserHandler : IHandleCommand<DeleteUserCommand>
    {
        protected IDataTransaction Transaction { get; private set; }

        public DeleteUserHandler(IDataTransaction tx)
        {
            Transaction = tx;
        }

        public void DoWork(DeleteUserCommand param)
        {
            var userToDelete =
                Transaction.Find<User>(user => user.Name.ToUpper() == param.Name.ToUpper())
                    .SingleOrDefault();

            if (userToDelete == null)
            {
                Transaction.Cancel();
                throw new DataCommandException("User doesn't exist.");
            }

            Console.WriteLine("Deleting user {0}", param.Name);
            Transaction.Delete(userToDelete);

            this.Transaction.Commit();
        }
    }
}
