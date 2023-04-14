using Autofac;
using EmployeeTrackingSystem.BusinessLayer.Mapping;
using EmployeeTrackingSystem.BusinessLayer.Services;
using EmployeeTrackingSystem.CoreLayer.Repositories;
using EmployeeTrackingSystem.CoreLayer.Services;
using EmployeeTrackingSystem.CoreLayer.UnitOfWorks;
using EmployeeTrackingSystem.DataAccessLayer.EntityFramework.Context;
using EmployeeTrackingSystem.DataAccessLayer.EntityFramework.Repositories;
using EmployeeTrackingSystem.DataAccessLayer.EntityFramework.UnitOfWorks;
using System.Reflection;

namespace EmployeeTrackingSystem.WebAPI.Modules
{
    public class RepositoryAndServiceModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Generic Repository
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();

            // Services
            builder.RegisterGeneric(typeof(Service<,>)).As(typeof(IService<,>)).InstancePerLifetimeScope();

            // UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();


            // Custom Repository ve Service'ler
            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(EmployeeTrackingSystemContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MappingProfile));
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
