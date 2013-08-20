using IocOrigins.Dal;
using IocOrigins.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.DataCommands.Services
{
    public class PromoteUserService : IPromoteUserService
    {
        public PromoteUserService()
        {
        }

        public void Promote(IDataTransaction tx, string username)
        {
            var userToPromote =
                tx.Find<User>(user => user.Name.ToUpper() == username.ToUpper())
                    .SingleOrDefault();

            if (userToPromote == null)
            {
                throw new Exception("User doesn't exist.");
            }

            Console.WriteLine("Promoting user {0} to admin.", username);
            userToPromote.IsAdmin = true;
        }
    }
}
