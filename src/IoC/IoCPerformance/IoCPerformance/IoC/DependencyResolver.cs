using IoCPerformance.IoC.Base;
using IoCPerformance.Services.Test;
using Unity;
using Xamarin.Forms;

namespace IoCPerformance.IoC
{
    public class DependencyResolver : IPerformance
    {
        private readonly int _numberOfTests;


        public DependencyResolver(int numberOfTests)
        {
            _numberOfTests = numberOfTests;
        }

        public void FirstResolve()
        {
            DependencyService.Get<ITestService>(DependencyFetchTarget.NewInstance);
        }

        public void Registration()
        {
            for (int x = 0; x < _numberOfTests; x++)
            {
                DependencyService.Register<ITestService, TestService>();
            }
        }

        public void Resolve()
        {
            for (int x = 0; x < _numberOfTests; x++)
            {
                var returnMe = DependencyService.Get<ITestService>(DependencyFetchTarget.NewInstance);
            }
        }
    }
}