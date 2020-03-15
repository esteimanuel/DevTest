using Refactoring.Application.Interfaces.Commands.AreaCalculator;
using Refactoring.Application.Enums;
using Refactoring.Application.Models;
using Refactoring.Application.Interfaces.Repository;
using Refactoring.Application.Interfaces.Services;
using System.Linq;
using Unity;

namespace Refactoring.Application.Commands.AreaCalculator
{
    public class AreaCalculatorCommand : IAreaCalculatorCommand
    {
        public AreaCalculatorOperations Operation { get; set; }
        public Shape Shape { get; set; }
        public IShapeRepository ShapeRepository { get; set; }
        public ILogger Logger { get; set; }

        public AreaCalculatorCommand(IShapeRepository shapeRepository, ILogger logger, AreaCalculatorOperations operation, Shape shape = null)
        {
            ShapeRepository = shapeRepository;
            Logger = logger;
            Operation = operation;
            Shape = shape;
        }

        public void Execute()
        {
            switch (Operation)
            {
                case AreaCalculatorOperations.Create:
                    CreateShape();
                    break;

                case AreaCalculatorOperations.Calculate:
                    CalculateSurfaceAreas();
                    break;

                case AreaCalculatorOperations.Print:
                    PrintSurfaceAreas();
                    break;

                case AreaCalculatorOperations.Reset:
                    ResetShapes();
                    break;
            }
        }

        private void CreateShape()
        {
            ShapeRepository.Add(Shape);
            Logger.Log($"{Shape.GetType().Name} created!");
        }

        private void CalculateSurfaceAreas()
        {
            var shapes = ShapeRepository.GetAll().ToList();

            if (!shapes.Any())
            {
                Logger.Log("There are no surface areas to calculate.");
                return;
            }

            shapes.Where(shape => !shape.Area.HasValue).ToList()
                .ForEach(shape => shape.CalculateSurfaceArea());
            Logger.Log("All surface areas calculated!");
        }

        private void PrintSurfaceAreas()
        {
            var shapes = ShapeRepository.GetAll().ToList();

            if (!shapes.Any())
            {
                Logger.Log("There are no surface areas to print.");
                return;
            }

            if (shapes.All(shape => shape.Area.HasValue))
                shapes.ForEach(shape => Logger.Log($"[{shapes.IndexOf(shape) + 1}] {shape.ToString()}"));
            else
                Logger.Log("First calculate shape areas!");
        }

        private void ResetShapes()
        {
            ShapeRepository.GetAll().ToList().ForEach(shape => ShapeRepository.Delete(shape));
            Logger.Log("Reset state!!");
        }
    }
}