using Autofac;
using demo.IRepository;
using demo.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace demo.extensions
{
    public class AutofacModuleRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //1. register le repository generique
            builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepositotyBase<>)).SingleInstance(); //InstancePerDependency();

            //2. register les services

            var basePath = AppContext.BaseDirectory;

            var servicesDllFile = Path.Combine(basePath, "demo.Service.dll");
            var repositoriesDllFile = Path.Combine(basePath, "demo.Repository.dll");

            if (!File.Exists(servicesDllFile) || !File.Exists(repositoriesDllFile))
            {
                throw new Exception("demo.Service.dll et demo.Repository.dll not found !!!");
            }

            var services = Assembly.LoadFrom(servicesDllFile);
            builder.RegisterAssemblyTypes(services)
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerDependency();

            var repositories = Assembly.LoadFrom(repositoriesDllFile);
            builder.RegisterAssemblyTypes(repositories)
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerDependency();

        }
    }
}
