using IocOrigins.Dal;
using IocOrigins.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.DataCommands
{
    public class PromoteUserHandler : DataCommandBase<PromoteUserCommand>
    {
        public override void DoWork(PromoteUserCommand param)
        {
            this.OpenTransaction("Promote user to admin");

            var userToPromote = this.Find<User>(user => user.Name.ToUpper() == param.Name.ToUpper())
                .SingleOrDefault();

            if (userToPromote == null)
            {
                this.Transaction.Cancel();
                throw new DataCommandException("User doesn't exist.");
            }

            Console.WriteLine("Promoting user {0} to admin.", param.Name);
            userToPromote.IsAdmin = true;

            this.Transaction.Commit();
        }
    }
}
