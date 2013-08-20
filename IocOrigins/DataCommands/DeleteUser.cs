using IocOrigins.Dal;
using IocOrigins.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.DataCommands
{
    public class DeleteUser
    {
        protected IDataTransaction Transaction { get; private set; }

        public DeleteUser(IDataTransaction tx)
        {
            Transaction = tx;
        }

        public void DoWork(string username)
        {
            var userToDelete =
                Transaction.Find<User>(user => user.Name.ToUpper() == username.ToUpper())
                    .SingleOrDefault();

            if (userToDelete == null)
            {
                Transaction.Cancel();
                throw new DataCommandException("User doesn't exist.");
            }

            Console.WriteLine("Deleting user {0}", username);
            Transaction.Delete(userToDelete);

            this.Transaction.Commit();
        }
    }
}
