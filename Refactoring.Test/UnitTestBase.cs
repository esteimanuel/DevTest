using Unity;

namespace Refactoring.Test
{
    public class UnitTestBase : TestBase
    {
        protected IUnityContainer MockContainer => Bootstrapper.MockContainer;
    }
}