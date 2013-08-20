using IocOrigins.Dal;
using IocOrigins.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.DataCommands
{
    public class CreateUser
    {
        protected IDataTransaction Transaction { get; private set; }

        public CreateUser(IDataTransaction tx)
        {
            Transaction = tx;
        }

        public void DoWork(string username)
        {
            if (username.IndexOfAny(",./;'[]\\-=!@#$%^&*()_+{}|:\"<>?".ToArray()) >= 0)
            {
                Transaction.Cancel();
                throw new DataCommandException("User name contains an invalid character.");
            }

            Console.WriteLine("Creating user {0}", username);

            var newId = new Random().Next(1, Int32.MaxValue);
            Transaction.Save(
                new User(newId) {
                    Name = username
                }
            );

            Transaction.Commit();
        }
    }
}
