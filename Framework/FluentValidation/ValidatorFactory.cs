using FluentValidation;
using FluentValidation.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.FluentValidation
{
    public class ValidatorFactory : AttributedValidatorFactory
    {
        private IServiceProvider _serviceProvider;

        public ValidatorFactory(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Gets a validator for the appropriate type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Created IValidator instance; null if a validator cannot be created</returns>
        public override IValidator GetValidator(Type type)
        {
            if (type == null)
                return null;

            //get a custom attribute applied to a member of a type
            var validatorAttribute = (ValidatorAttribute)Attribute.GetCustomAttribute(type, typeof(ValidatorAttribute));
            if (validatorAttribute == null || validatorAttribute.ValidatorType == null)
                return null;

            //try to create instance of the validator
            var instance = ResolveUnregistered(validatorAttribute.ValidatorType);

            return instance as IValidator;
        }

        public virtual object ResolveUnregistered(Type type)
        {
            Exception innerException = null;
            foreach (var constructor in type.GetConstructors())
            {
                try
                {
                    //try to resolve constructor parameters
                    var parameters = constructor.GetParameters().Select(parameter =>
                    {
                        var service = _serviceProvider.GetRequiredService(type);
                        if (service == null)
                            throw new Exception("Unknown dependency");
                        return service;
                    });

                    //all is ok, so create instance
                    return Activator.CreateInstance(type, parameters.ToArray());
                }
                catch (Exception ex)
                {
                    innerException = ex;
                }
            }

            throw new Exception("No constructor was found that had all the dependencies satisfied.", innerException);
        }
    }
}