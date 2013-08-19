using IocOrigins.Dal;
using IocOrigins.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.DataCommands
{
    public class CreateUserHandler : IHandleCommand<CreateUserCommand>
    {
        protected IDataTransaction Transaction { get; private set; }

        public CreateUserHandler(IDataTransaction tx)
        {
            Transaction = tx;
        }

        public void DoWork(CreateUserCommand param)
        {
            if (param.Name.IndexOfAny(",./;'[]\\-=!@#$%^&*()_+{}|:\"<>?".ToArray()) >= 0)
            {
                Transaction.Cancel();
                throw new DataCommandException("User name contains an invalid character.");
            }

            Console.WriteLine("Creating user {0}", param.Name);

            var newId = new Random().Next(1, Int32.MaxValue);
            Transaction.Save(
                new User(newId) {
                    Name = param.Name
                }
            );

            Transaction.Commit();
        }
    }
}
