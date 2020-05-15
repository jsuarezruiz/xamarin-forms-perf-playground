using IoCPerformance.IoC.Base;
using IoCPerformance.Services.Test;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IoCPerformance.IoC
{
    public class NetCoreServiceProvider : IPerformance
    {
        private int _numberOfTests;
        IServiceProvider _serviceProvider;

        public NetCoreServiceProvider(int numberOfTests)
        {
            _numberOfTests = numberOfTests;
        }

        public void Registration()
        {
            for (int x = 0; x < _numberOfTests; x++)
            {
                ServiceCollection serviceCollection = new ServiceCollection();
                serviceCollection.AddTransient<ITestService, TestService>();
                _serviceProvider = serviceCollection.BuildServiceProvider();
            }
        }

        public void FirstResolve()
        {
            var returnMe = _serviceProvider.GetService<ITestService>();
        }

        public void Resolve()
        {
            for (int x = 0; x < _numberOfTests; x++)
            {
                var returnMe = _serviceProvider.GetService<ITestService>();
            }
        }
    }
}
