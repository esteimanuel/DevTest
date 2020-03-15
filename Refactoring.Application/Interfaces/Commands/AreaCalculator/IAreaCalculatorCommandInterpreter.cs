namespace Refactoring.Application.Interfaces.Commands.AreaCalculator
{
    public interface IAreaCalculatorCommandInterpreter
    {
        IAreaCalculatorCommand InterpretAreaCalculatorCommand(string userInput);
    }
}