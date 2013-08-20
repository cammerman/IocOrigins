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
        public CreateUserService()
        {
        }

        public void Create(IDataTransaction tx, string username)
        {
            if (username.IndexOfAny(",./;'[]\\-=!@#$%^&*()_+{}|:\"<>?".ToArray()) >= 0)
            {
                throw new Exception("User name contains an invalid character.");
            }

            Console.WriteLine("Creating user {0}", username);

            var newId = new Random().Next(1, Int32.MaxValue);
            tx.Save(
                new User(newId) {
                    Name = username
                }
            );
        }
    }
}
