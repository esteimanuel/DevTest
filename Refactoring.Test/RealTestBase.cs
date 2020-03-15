using Unity;

namespace Refactoring.Test
{
    public class RealTestBase : TestBase
    {
        protected IUnityContainer RealContainer => Bootstrapper.RealContainer;
    }
}