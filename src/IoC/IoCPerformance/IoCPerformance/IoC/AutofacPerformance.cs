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

        public AutofacPerformance(int numberOfTests)
        {
            _numberOfTests = numberOfTests;

            _builder = new ContainerBuilder();
        }

        public void Registration()
        {
            for (int x = 0; x < _numberOfTests; x++)
            {
                _builder.RegisterType<TestService>().As<ITestService>().Named<TestService>(string.Format("Class{0}", x));
            }

            _container = _builder.Build();
        }

        public void Resolve()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                for (int x = 0; x < _numberOfTests; x++)
                {
                    scope.ResolveNamed<TestService>(string.Format("Class{0}", x));
                }
            }
        }
    }
}