using IocOrigins.Dal;
using IocOrigins.DataCommands;
using IocOrigins.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins
{
    class Program
    {
        static string _connectionString = "localhost:80";

        static User UserWithId(int id)
        {
            return new User(id) {
                 Name = String.Format("User{0}", id),
                 IsAdmin = (id % 2) == 0
            };
        }

        static void Main(string[] args)
        {
            var options = new CliOptions();

            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                var data =
                    Enumerable.Range(1, 10)
                        .Select(UserWithId)
                        .Cast<object>()
                        .ToList();

                var manager = new DataManager(_connectionString, data);
                var succeeded = false;

                // consume Options instance properties
                if (options.UserToCreate != null)
                {
                    succeeded = manager.ExecuteCommand<CreateUserHandler, CreateUserCommand>(new CreateUserCommand {
                        Name = options.UserToCreate
                    });

                    if (succeeded && options.Admin) {
                        succeeded = manager.ExecuteCommand<PromoteUserHandler, PromoteUserCommand>(new PromoteUserCommand {
                            Name = options.UserToPromote
                        });
                    }
                }
                else if (options.UserToDelete != null)
                {
                    succeeded = manager.ExecuteCommand<DeleteUserHandler, DeleteUserCommand>(new DeleteUserCommand {
                        Name = options.UserToDelete
                    });
                }

                if (succeeded)
                {
                    Console.WriteLine("Command succeded.");
                }
                else
                {
                    Console.WriteLine("Command failed.");
                }
            }
        }
    }
}
