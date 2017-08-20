// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// Program.cs 
// 20 / 08 / 2017

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using Refactoring.Extensions;
using Refactoring.Logging;
using Refactoring.Shapes;

namespace Refactoring
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ILogger consoleLogger = new Logger();

            consoleLogger.Log(" -------------------------------------------------------------------------- ");
            consoleLogger.Log("| Greetings and salutations fellow developer :D                            |");
            consoleLogger.Log("|                                                                          |");
            consoleLogger.Log("| If you are reading this we probably want to know if you know your stuff. |");
            consoleLogger.Log("|                                                                          |");
            consoleLogger.Log("| How would you improve this code?                                         |");
            consoleLogger.Log("| We challenge you to refactor this and show us how awesome you are ;)     |");
            consoleLogger.Log("| We also really like trapezoids so could you also implement that for us?  |");
            consoleLogger.Log("|                                                                          |");
            consoleLogger.Log("|                                                               Good luck! |");
            consoleLogger.Log(" --------------------------------------------------------------------------");

            SurfaceAreaCalculator surfaceAreaCalculator = new SurfaceAreaCalculator(consoleLogger);
            ShapeCreator shapeCreator = new ShapeCreator(consoleLogger);
            InputHandler inputHandler = new InputHandler(consoleLogger, GetAvailableInputCommands());

            inputHandler.ShowCommands();

            bool canExit = false;
            while (!canExit)
            {
                var command = inputHandler.ParseCommand(Console.ReadLine());
                if (command == null)
                {
                    consoleLogger.Log("Unknown command!!!");
                    inputHandler.ShowCommands();
                }
                else if (command.Keyword.Equals("exit"))
                {
                    canExit = true;
                }
                else
                {
                    HandleCommand(command, shapeCreator, surfaceAreaCalculator);
                }
            }
            Console.ReadKey();
        }

        private static void HandleCommand(IInputCommand command, ShapeCreator shapeCreator, SurfaceAreaCalculator surfaceAreaCalculator)
        {
            switch (command.Keyword)
            {
                case "create":
                    IShape shape = shapeCreator.CreateShapeFromCommand(command);
                    surfaceAreaCalculator.Add(shape);
                    break;
                case "print":
                    surfaceAreaCalculator.LogSurfaceAreas();
                    break;
                case "calculate":
                    surfaceAreaCalculator.CalculateSurfaceAreas();
                    break;
                case "reset":
                    surfaceAreaCalculator.ResetSurfaceAreas();
                    break;
                case "exit":
                    break;
            }
        }

        private static List<IInputCommand> GetAvailableInputCommands()
        {
            InputParameter<double> doubleParameter = new InputParameter<double>("double");
            InputParameter<int> heightParameter = new InputParameter<int>("height");
            InputParameter<int> widthParameter = new InputParameter<int>("width");

            return new List<IInputCommand>
            {
                new CreateShapeInputCommand(ShapeType.Square, doubleParameter),
                new CreateShapeInputCommand(ShapeType.Circle, doubleParameter),
                new CreateShapeInputCommand(ShapeType.Rectangle, heightParameter, widthParameter),
                new CreateShapeInputCommand(ShapeType.Triangle, heightParameter, widthParameter),
                new InputCommand("print", string.Empty, "print the calculated surface areas"),
                new InputCommand("calculate", string.Empty, "calulate the surface areas of the created shapes"),
                new InputCommand("reset", string.Empty, "reset"),
                new InputCommand("exit", string.Empty, "exit the loop")
            };
        }
    }

    public class ShapeCreator 
    {
        private readonly ILogger _logger;

        public ShapeCreator(ILogger logger)
        {
            _logger = logger;
        }
        
        public IShape GetSquare(double side)
        {
            IShape square = new Square
            {
                Side = side
            };

            _logger.Log($"{square.GetType().Name} created!");
            return square;
        }

        public IShape GetCircle(double radius)
        {
            IShape circle = new Circle
            {
                Radius = radius
            };

            _logger.Log($"{circle.GetType().Name} created!");
            return circle;
        }

        public IShape GetRectangle(int height, int width)
        {
            IShape rectangle = new Rectangle
            {
                Height = height,
                Width = width
            };

            _logger.Log($"{rectangle.GetType().Name} created!");
            return rectangle;
        }

        public IShape GetTriangle(int height, int width)
        {
            IShape triangle = new Triangle
            {
                Height = height,
                Width = width
            };

            _logger.Log($"{triangle.GetType().Name} created!");
            return triangle;
        }

        public IShape CreateShapeFromCommand(IInputCommand command)
        {
            throw new NotImplementedException();
        }
    }

    public class InputHandler
    {
        private readonly ILogger _logger;
        private readonly List<IInputCommand> _availableCommands;

        public InputHandler(ILogger log, List<IInputCommand> availableCommands)
        {
            _logger = log;
            _availableCommands = availableCommands;
        }
        
        public void ShowCommands()
        {
            _logger.Log("commands:");
            _availableCommands.ForEach(command => _logger.Log(command.ToString()));
        }

        public IInputCommand ParseCommand(string pCommand)
        {
            if (string.IsNullOrEmpty(pCommand))
            {
                return null;
            }

            string[] arrCommands = pCommand.Split(' ');
            if (arrCommands.Length == 0)
            {
                return null;
            }

            if (arrCommands[0].ToLower().Equals("create"))
            {
                return arrCommands.Length > 1 ? ParseCreateCommand(arrCommands) : null;
            }

            IInputCommand enteredCommand = _availableCommands.FirstOrDefault(command => command.Keyword.Equals(arrCommands[0]));
            return enteredCommand;
        }

        private IInputCommand ParseCreateCommand(string[] arrCommands)
        {
            string shapeName = arrCommands[1].ToLower();

            IInputCommand shape = _availableCommands.FirstOrDefault(command => command.KeywordModifier.Equals(shapeName));
            CreateShapeInputCommand shapeInputCommand = shape as CreateShapeInputCommand;
            if (shapeInputCommand == null)
            {
                return null;
            }

            return shapeInputCommand.TrySetParameterValues(arrCommands) ? shapeInputCommand : null;
        }
    }

    public interface IInputCommand
    {
        string Keyword { get; }
        string KeywordModifier { get; }
        string Description { get; }
    }

    public class InputCommand : IInputCommand
    {
        public InputCommand(string keyword, string keywordModifier, string description)
        {
            Keyword = keyword;
            KeywordModifier = keywordModifier;
            Description = description;
        }

        public string Keyword { get; }
        public string KeywordModifier { get; set; }
        public string Description { get; }

        public override string ToString()
        {
            return $"- {Keyword} ({Description})";
        }
    }

    public class CreateShapeInputCommand : InputCommand
    {
        private readonly List<IInputParameter> _paramList;
        public ShapeType ShapeType { get; }

        public CreateShapeInputCommand(ShapeType type, params IInputParameter[] paramList) : base("create", type.GetDescription().ToLower(), GetDescription(type))
        {
            ShapeType = type;
            _paramList = paramList.ToList();
        }

        private static string GetDescription(ShapeType type)
        {
            return $"create a new {type.GetDescription()}";
        }

        public override string ToString()
        {
            var paramStringBuilder = new StringBuilder();
            _paramList.ForEach(inputParam => paramStringBuilder.Append($" {{{inputParam.ParameterDescription}}}"));

            return $"- {Keyword} {KeywordModifier}{paramStringBuilder} ({Description})";
        }

        public bool TrySetParameterValues(string[] arrCommands)
        {
            int startIndex = 2;
            if (_paramList.Count > arrCommands.Length - 2)
            {
                return false;
            }

            foreach (IInputParameter inputParameter in _paramList)
            {
                if (!inputParameter.SetValue(arrCommands[startIndex]))
                {
                    return false;
                }
                startIndex++;
            }

            return true;
        }
    }

    public class InputParameter<T> : IInputParameter
    {
        public string ParameterDescription { get; }
        public T Value { get; private set; }

        public bool SetValue(string unparsedValue)
        {
            try
            {
                Value = (T) Convert.ChangeType(unparsedValue, typeof(T), CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                return false; // unable to parse I guess..
            }
            return true;
        }

        public InputParameter(string parameterDescription)
        {
            ParameterDescription = parameterDescription;
        }
    }

    public interface IInputParameter
    {
        string ParameterDescription { get; }
        bool SetValue(string unparsedValue);
    }
}