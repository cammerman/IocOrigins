using IocOrigins.Dal;
using IocOrigins.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.DataCommands
{
    public class DeleteUserHandler : DataCommandBase<DeleteUserCommand>
    {
        public override void DoWork(DeleteUserCommand param)
        {
            this.OpenTransaction("Delete user");

            var userToDelete = this.Find<User>(user => user.Name.ToUpper() == param.Name).SingleOrDefault();

            if (userToDelete == null)
            {
                this.Transaction.Cancel();
                throw new DataCommandException("User doesn't exist.");
            }

            Console.WriteLine("Deleting user {0}", param.Name);
            this.Delete(userToDelete);

            this.Transaction.Commit();
        }
    }
}
