namespace IoCPerformance.IoC.Base
{
    public interface IPerformance
    {
        void Registration();

        void Resolve();

        void FirstResolve();
    }
}