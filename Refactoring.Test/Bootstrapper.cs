using Moq;
using Refactoring.Application.Interfaces.Commands.AreaCalculator;
using Refactoring.Application.Interfaces.Repository;
using Refactoring.Application.Interfaces.Services;
using System;
using Unity;
using Unity.Lifetime;

namespace Refactoring.Test
{
    public static class Bootstrapper
    {
        // In this case both containers will store the same registrations, but separating them allows to perform unit and real tests easily
        private static Lazy<IUnityContainer> _realContainer = new Lazy<IUnityContainer>(() => RegisterTypes(new UnityContainer()));

        private static Lazy<IUnityContainer> _mockContainer = new Lazy<IUnityContainer>(() => RegisterMockTypes(new UnityContainer()));

        public static IUnityContainer RealContainer => _realContainer.Value;
        public static IUnityContainer MockContainer => _mockContainer.Value;

        private static IUnityContainer RegisterTypes(IUnityContainer container)
        {
            container.RegisterInstance(new Mock<ILogger>().Object);
            container.RegisterType<IShapeRepository, Repository.Memory.ShapeRepository>(new PerThreadLifetimeManager());
            container.RegisterType<IAreaCalculatorCommandInterpreter, Application.Commands.AreaCalculator.AreaCalculatorCommandInterpreter>();

            return container;
        }

        private static IUnityContainer RegisterMockTypes(IUnityContainer container)
        {
            container.RegisterInstance(new Mock<ILogger>().Object);
            container.RegisterType<IShapeRepository, Repository.Memory.ShapeRepository>();
            container.RegisterType<IAreaCalculatorCommandInterpreter, Application.Commands.AreaCalculator.AreaCalculatorCommandInterpreter>();

            return container;
        }
    }
}