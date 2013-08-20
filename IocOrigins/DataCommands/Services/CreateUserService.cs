using IocOrigins.Dal;
using IocOrigins.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.DataCommands.Services
{
    public class CreateUserService : ICreateUserService
    {
        protected virtual IDataTransaction Transaction { get; private set; }

        public CreateUserService(IDataTransaction tx)
        {
            Transaction = tx;
        }

        public void Create(string username)
        {
            if (username.IndexOfAny(",./;'[]\\-=!@#$%^&*()_+{}|:\"<>?".ToArray()) >= 0)
            {
                throw new Exception("User name contains an invalid character.");
            }

            Console.WriteLine("Creating user {0}", username);

            var newId = new Random().Next(1, Int32.MaxValue);
            Transaction.Save(
                new User(newId) {
                    Name = username
                }
            );
        }
    }
}
