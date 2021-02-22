using Autofac;
using Core;
using Core.Infrastructure;
using Autofac.Core;
using System.Reflection;
using System.Collections.Generic;
using System;
using Autofac.Builder;
using Services.GovAPI;

namespace Framework.Infrastructure
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="APIConfig">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            //file provider
            builder.RegisterType<AppFileProvider>().As<IAppFileProvider>().InstancePerLifetimeScope();

            builder.RegisterType<GovAPIService>().As<IGovAPIService>().InstancePerLifetimeScope();
            //register all settings
            builder.RegisterSource(new SettingsSource());
        }

        /// <summary>
        /// Gets order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 0; }
        }

        /// <summary>
        /// Setting source
        /// </summary>
        public class SettingsSource : IRegistrationSource
        {
            static readonly MethodInfo BuildMethod = typeof(SettingsSource).GetMethod(
                "BuildRegistration",
                BindingFlags.Static | BindingFlags.NonPublic);

            /// <summary>
            /// Registrations for
            /// </summary>
            /// <param name="service">Service</param>
            /// <param name="registrations">Registrations</param>
            /// <returns>Registrations</returns>
            public IEnumerable<IComponentRegistration> RegistrationsFor(
                Service service,
                Func<Service, IEnumerable<IComponentRegistration>> registrations)
            {
                var ts = service as TypedService;
                if (ts != null && typeof(Type).IsAssignableFrom(ts.ServiceType))
                {
                    var buildMethod = BuildMethod.MakeGenericMethod(ts.ServiceType);
                    yield return (IComponentRegistration)buildMethod.Invoke(null, null);
                }
            }

            /// <summary>
            /// Is adapter for individual components
            /// </summary>
            public bool IsAdapterForIndividualComponents { get { return false; } }
        }
    }
}