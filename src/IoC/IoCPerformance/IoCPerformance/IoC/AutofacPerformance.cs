using Autofac;
using IoCPerformance.IoC.Base;
using IoCPerformance.Services.Test;

namespace IoCPerformance.IoC
{
    public class AutofacPerformance : IPerformance
    {
        private readonly int _numberOfTests;

        private static ContainerBuilder _builder { get; set; }
        private static IContainer _container { get; set; }

        ILifetimeScope _scope;

        public AutofacPerformance(int numberOfTests)
        {
            _numberOfTests = numberOfTests;

            _builder = new ContainerBuilder();
        }

        public void Registration()
        {
            for (int x = 0; x < _numberOfTests + 1; x++)
            {
                _builder.RegisterType<TestService>().As<ITestService>().Named<TestService>(string.Format("Class{0}", x));
            }

            _container = _builder.Build();
            _scope = _container.BeginLifetimeScope();
        }

        public void FirstResolve()
        {
            _scope.ResolveNamed<TestService>(string.Format("Class{0}", "0"));
        }

        public void Resolve()
    {
            for (int x = 1; x < _numberOfTests + 1; x++)
            {
                _scope.ResolveNamed<TestService>(string.Format("Class{0}", x));
            }
        }
    }
}