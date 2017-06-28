using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using Autofac;
using Autofac.Integration.Mvc;
using Cp.Core.Autofacs;
using Cp.Core.Data;
using CpMvc.Data;
using CpMvc.Data.EntityFramework;

namespace CpMVC.Services
{
    public class DependencyRegistrar: IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            ////controllers
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());

            ////data layer
            builder.Register<IDbContext>(c => new MvcContext()).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            // 自动注册Service
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>()
                .Where(
                    assembly =>
                        assembly.GetTypes().FirstOrDefault(type => type.GetInterfaces().Contains(typeof(IBaseService))) !=
                        null
                );

            // RegisterAssemblyTypes 注册程序集
            var enumerable = assemblies as Assembly[] ?? assemblies.ToArray();
            if (enumerable.Any())
            {
                builder.RegisterAssemblyTypes(enumerable)
                    .Where(type => type.GetInterfaces().Contains(typeof(IBaseService))).AsImplementedInterfaces().InstancePerDependency();
            }
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 0; }
        }
    }
}