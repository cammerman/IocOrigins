using IocOrigins.CommandInfra;
using IocOrigins.Dal;
using IocOrigins.DataCommands;
using IocOrigins.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

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

                var container = SetupContainer.Build(
                    new InMemoryDataStore(data));

                // Get to work.
                var router = new RouteCommand(container);
                Execute(options, router);

                container.Dispose();
            }
        }

        static void Execute(CliOptions options, IRouteCommand router)
        {
            if (options.UserToCreate != null && !options.Admin)
            {
                router.Route(
                    new CreateUserCommand {
                        Username = options.UserToCreate });
            }

            if (options.UserToCreate != null && options.Admin)
            {
                if (options.Admin) {
                    router.Route(
                        new CreateAdminUserCommand {
                            Username = options.UserToCreate });
                }
            }
            
            if (options.UserToPromote != null)
            {
                router.Route(
                    new PromoteUserCommand {
                        Username = options.UserToPromote });
            }
            
            if (options.UserToDelete != null)
            {
                router.Route(
                    new DeleteUserCommand {
                        Username = options.UserToDelete });
            }
        }
    }
}
