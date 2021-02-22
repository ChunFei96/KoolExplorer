using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Core.Configuration;
using Microsoft.AspNetCore.Builder;
using Autofac.Extensions.DependencyInjection;
using Core.Infrastructure;
using FluentValidation.AspNetCore;
using Framework.FluentValidation;
using Autofac;
//using Core.Infrastructure.DependencyManagement;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Core;
using AutoMapper;
using Core.Infrastructure.Mapper;

namespace Framework.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceProvider ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            //add URLConfig configuration parameters
            //services.ConfigureStartupConfig<URLConfig>(configuration.GetSection("URL"));

            // Use In-memory caching
            services.AddMemoryCache();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //add accessor to HttpContext
            services.AddHttpContextAccessor();

            //add and configure MVC feature
            services.AddMvcConfiguration();

            //add authentication
            services.AddAuthentication();

            //Add constraints
            services.AddRouting();

            //initiliaze HTML to PDF
            //var hostingEnvironment = services.BuildServiceProvider().GetRequiredService<IHostingEnvironment>();
            //CommonHelper.DefaultFileProvider = new AppFileProvider(hostingEnvironment);

            var typeFinder = new WebAppTypeFinder();

            //register mapper configurations
            AddAutoMapper(services, typeFinder);

            //register dependencies
            return RegisterDependencies(services, typeFinder);
        }

        /// <summary>
        /// Create, bind and register as service the specified configuration parameters 
        /// </summary>
        /// <typeparam name="TConfig">Configuration parameters</typeparam>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Set of key/value application configuration properties</param>
        /// <returns>Instance of configuration parameters</returns>
        public static TConfig ConfigureStartupConfig<TConfig>(this IServiceCollection services, IConfiguration configuration) where TConfig : class, new()
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            //create instance of config
            var config = new TConfig();

            //bind it to the appropriate section of configuration
            configuration.Bind(config);

            //and register it as a service
            services.AddSingleton(config);

            return config;
        }

        /// <summary>
        /// Add and configure MVC for the application
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <returns>A builder for configuring MVC services</returns>
        public static IMvcBuilder AddMvcConfiguration(this IServiceCollection services)
        {
            //add basic MVC feature
            var mvcBuilder = services.AddMvc();

            //sets the default value of settings on MvcOptions to match the behavior of asp.net core mvc 2.2
            mvcBuilder
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressConsumesConstraintForFormFileParameters = true;
                    options.SuppressInferBindingSourcesForParameters = true;
                    options.SuppressModelStateInvalidFilter = true;
                    options.SuppressMapClientErrors = true;
                });

            //add fluent validation
            mvcBuilder.AddFluentValidation(configuration =>
            {
                configuration.ValidatorFactoryType = typeof(ValidatorFactory);
                configuration.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            });

            return mvcBuilder;
        }


        /// <summary>
        /// Register dependencies using Autofac
        /// </summary>
        /// <param name="nopConfig">Startup Nop configuration parameters</param>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="typeFinder">Type finder</param>
        public static IServiceProvider RegisterDependencies(IServiceCollection services, ITypeFinder typeFinder)
        {
            var builder = new ContainerBuilder();

            //register type finder
            builder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();

            //find dependency registrars provided by other assemblies
            var dependencyRegistrars = typeFinder.FindClassesOfType<IDependencyRegistrar>();

            //create and sort instances of dependency registrars
            var instances = dependencyRegistrars
                //.Where(dependencyRegistrar => PluginManager.FindPlugin(dependencyRegistrar)?.Installed ?? true) //ignore not installed plugins
                .Select(dependencyRegistrar => (IDependencyRegistrar)Activator.CreateInstance(dependencyRegistrar))
                .OrderBy(dependencyRegistrar => dependencyRegistrar.Order);

            //register all provided dependencies
            foreach (var dependencyRegistrar in instances)
                dependencyRegistrar.Register(builder, typeFinder);

            //populate Autofac container builder with the set of registered service descriptors
            builder.Populate(services);

            //create service provider
            return new AutofacServiceProvider(builder.Build());
        }

        /// <summary>
        /// Register and configure AutoMapper
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="typeFinder">Type finder</param>
        public static void AddAutoMapper(IServiceCollection services, ITypeFinder typeFinder)
        {
            //find mapper configurations provided by other assemblies
            var mapperConfigurations = typeFinder.FindClassesOfType<IOrderedMapperProfile>();

            //create and sort instances of mapper configurations
            var instances = mapperConfigurations
                //.Where(mapperConfiguration => PluginManager.FindPlugin(mapperConfiguration)?.Installed ?? true) //ignore not installed plugins
                .Select(mapperConfiguration => (IOrderedMapperProfile)Activator.CreateInstance(mapperConfiguration))
                .OrderBy(mapperConfiguration => mapperConfiguration.Order);

            //create AutoMapper configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DateTime, DateTime>().ConvertUsing<UtcToLocalConverter>();

                foreach (var instance in instances)
                {
                    cfg.AddProfile(instance.GetType());
                }
            });

            //register
            AutoMapperConfiguration.Init(config);
        }
    }
}