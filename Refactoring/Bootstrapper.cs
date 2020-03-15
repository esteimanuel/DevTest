using Refactoring.Application.Interfaces.Services;
using Refactoring.Application.Interfaces.Repository;
using Refactoring.Application.Interfaces.Commands.AreaCalculator;
using System;
using Unity;

namespace Refactoring
{
    public static class Bootstrapper
    {
        private static Lazy<IUnityContainer> _container = new Lazy<IUnityContainer>(() => RegisterTypes(new UnityContainer()));

        public static IUnityContainer Container => _container.Value;

        private static IUnityContainer RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ILogger, ConsoleLogger>();
            container.RegisterType<IShapeRepository, Repository.Memory.ShapeRepository>();
            container.RegisterType<IAreaCalculatorCommandInterpreter, Application.Commands.AreaCalculator.AreaCalculatorCommandInterpreter>();

            return container;
        }
    }
}