using Autofac;
using IocOrigins.CommandInfra;
using IocOrigins.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins
{
    public static class SetupContainer
    {
        public static IContainer Build(IDataStore dataStore)
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterAssemblyTypes(
                    Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterInstance(dataStore)
                .As<IDataStore>()
                .SingleInstance();

            builder.RegisterType<DataManager>()
                .AsSelf()
                .SingleInstance();
                
            builder
                .Register(context =>
                    context.Resolve<DataManager>()
                        .BeginTransaction())
                .As<IDataTransaction>()
                .InstancePerDependency();

            return builder.Build();
        }
    }
}
