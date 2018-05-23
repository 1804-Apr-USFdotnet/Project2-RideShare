using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Integration.WebApi;
using RideAlongAPI.Core;
using RideAlongAPI.Persistence;

namespace RideAlongAPI.App_Start
{
    public class DIRegister
    {
        private static IContainer _container;

        public static IContainer RegisterTypes()
        {
            var builder = new ContainerBuilder();

            // register
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerLifetimeScope();

            _container = builder.Build();

            return _container;
        }
    }
}