using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using ValidationProject.Models;
using ValidationProject.Validators;

namespace ValidationProject
{
    public class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            RegisterServices();

            // add service and do something
            var validatorServices = _serviceProvider.GetServices<ICallConnectValidator>();

            var sampleCallConnectModel = BuildSampleModel();

            foreach(var service in validatorServices)
            {
                service.Validate(sampleCallConnectModel);
            }

            DisposeServices();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ICallConnectValidator, PhoneNumberValidator>();
            _serviceProvider = services.BuildServiceProvider();
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }

            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }

        private static CallConnectModel BuildSampleModel()
        {
            return new CallConnectModel()
            {
                PhoneNumber = "61458208101",
                BusinessDays = new List<string> { "Sunday", "Monday", "Friday" },
                BusinessHoursClosing = 16.30,
                BusinessHoursOpening = 11.45,
                RingTimeout = 30
            };
        }
    }
}
