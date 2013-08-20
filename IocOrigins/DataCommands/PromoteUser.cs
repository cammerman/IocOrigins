using IocOrigins.Dal;
using IocOrigins.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.DataCommands
{
    public class PromoteUser
    {
        protected IDataTransaction Transaction { get; private set; }

        public PromoteUser(IDataTransaction tx)
        {
            Transaction = tx;
        }

        public void DoWork(string username)
        {
            var userToPromote =
                Transaction.Find<User>(user => user.Name.ToUpper() == username.ToUpper())
                    .SingleOrDefault();

            if (userToPromote == null)
            {
                Transaction.Cancel();
                throw new DataCommandException("User doesn't exist.");
            }

            Console.WriteLine("Promoting user {0} to admin.", username);
            userToPromote.IsAdmin = true;

            Transaction.Commit();
        }
    }
}
