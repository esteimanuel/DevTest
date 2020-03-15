using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.Application.Enums;
using Refactoring.Application.Interfaces.Commands.AreaCalculator;
using Refactoring.Application.Models.Shapes;
using Unity;

namespace Refactoring.Test.Unit
{
    [TestClass]
    public class AreaCalculatorCommandInterpreterTest : UnitTestBase
    {
        [TestMethod, TestCategory("Unit")]
        public void InterpretAreaCalculatorCommand_CreateSquare()
        {
            // Arrange
            var commandInterpreter = MockContainer.Resolve<IAreaCalculatorCommandInterpreter>();
            var userInput = $"create square {SquareSide.ToString()}";

            // Act
            var command = commandInterpreter.InterpretAreaCalculatorCommand(userInput);

            // Assert
            Assert.IsNotNull(command);
            Assert.IsNotNull(command.Shape);
            Assert.IsNull(command.Shape.Area);
            Assert.IsTrue(command.Shape is Square);
            Assert.AreEqual(AreaCalculatorOperations.Create, command.Operation);
            Assert.AreEqual(SquareSide, ((Square)command.Shape).Height);
            Assert.AreEqual(SquareSide, ((Square)command.Shape).Width);
        }

        // TODO: Test another command interpretations
    }
}