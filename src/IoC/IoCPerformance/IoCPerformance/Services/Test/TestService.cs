using System.Diagnostics;

namespace IoCPerformance.Services.Test
{
    public class TestService : ITestService
    {
        public void Test()
        {
            Debug.WriteLine("Test");
        }
    }
}