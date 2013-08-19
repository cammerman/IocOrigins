using IocOrigins.Dal;
using IocOrigins.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.DataCommands
{
    public class CreateUserHandler : DataCommandBase<CreateUserCommand>
    {
        public override void DoWork(CreateUserCommand param)
        {
            this.OpenTransaction("Create user");

            if (param.Name.IndexOfAny(",./;'[]\\-=!@#$%^&*()_+{}|:\"<>?".ToArray()) >= 0)
            {
                this.Transaction.Cancel();
                throw new DataCommandException("User name contains an invalid character.");
            }

            Console.WriteLine("Creating user {0}", param.Name);

            var newId = new Random().Next(1, Int32.MaxValue);
            this.Save(
                new User(newId) {
                    Name = param.Name
                }
            );

            this.Transaction.Commit();
        }
    }
}
