using Refactoring.Application.Enums;
using Refactoring.Application.Models;

namespace Refactoring.Application.Interfaces.Commands.AreaCalculator
{
    public interface IAreaCalculatorCommand : ICommand
    {
        AreaCalculatorOperations Operation { get; set; }
        Shape Shape { get; set; }
    }
}