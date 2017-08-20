// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// Program.cs 
// 20 / 08 / 2017

using System;
using System.Collections.Generic;
using Refactoring.DataModels.Input;
using Refactoring.DataModels.Logging;
using Refactoring.DataModels.Shapes;
using Refactoring.Enums;

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

        private static void HandleCommand(IInputCommand command, ShapeCreator shapeCreator,
            SurfaceAreaCalculator surfaceAreaCalculator)
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
            }
        }

        private static List<IInputCommand> GetAvailableInputCommands()
        {
            InputParameter<double> doubleParameter = new InputParameter<double>("double");
            InputParameter<double> baseBottomParameter = new InputParameter<double>("bottom base");
            InputParameter<double> baseTopParameter = new InputParameter<double>("top base");
            InputParameter<double> heightParameter = new InputParameter<double>("height");
            InputParameter<double> widthParameter = new InputParameter<double>("width");

            return new List<IInputCommand>
            {
                new CreateShapeInputCommand(ShapeType.Square, doubleParameter),
                new CreateShapeInputCommand(ShapeType.Circle, doubleParameter),
                new CreateShapeInputCommand(ShapeType.Rectangle, heightParameter, widthParameter),
                new CreateShapeInputCommand(ShapeType.Triangle, heightParameter, widthParameter),
                new CreateShapeInputCommand(ShapeType.Trapezoid, baseTopParameter, baseBottomParameter, heightParameter),
                new InputCommand("print", string.Empty, "print the calculated surface areas"),
                new InputCommand("calculate", string.Empty, "calulate the surface areas of the created shapes"),
                new InputCommand("reset", string.Empty, "reset"),
                new InputCommand("exit", string.Empty, "exit the loop")
            };
        }
    }
}