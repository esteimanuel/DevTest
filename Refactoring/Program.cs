using System;
using System.Collections.Generic;
using Refactoring.Services;
using Refactoring.Services.Commands;
using Refactoring.Services.Commands.Executors;
using Refactoring.Services.Figures;
using Refactoring.Services.Figures.Creators;
using Refactoring.Services.Utils;

namespace Refactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" -------------------------------------------------------------------------- ");
            Console.WriteLine("| Greetings and salutations fellow developer :D                            |");
            Console.WriteLine("|                                                                          |");
            Console.WriteLine("| If you are reading this we probably want to know if you know your stuff. |");
            Console.WriteLine("|                                                                          |");
            Console.WriteLine("| How would you improve this code?                                         |");
            Console.WriteLine("| We challenge you to refactor this and show us how awesome you are ;)     |");
            Console.WriteLine("| We also really like trapezoids so could you also implement that for us?  |");
            Console.WriteLine("|                                                                          |");
            Console.WriteLine("|                                                               Good luck! |");
            Console.WriteLine(" --------------------------------------------------------------------------");

            var surfaceAreaCalculator = BuildSurfaceAreaCalculator();
            surfaceAreaCalculator.Run();
            Console.ReadKey();
        }

        private static SurfaceAreaCalculator BuildSurfaceAreaCalculator()
        {
            var logger = new Logger();
            var figuresStorage = new FiguresStorage();

            var figureCreators = new List<IFigureCreator>
            {
                new SquareCreator(),
                new CircleCreator(),
                new TriangleCreator(),
                new RectangleCreator(),
                new TrapezoidCreator()
            };

            var figureCreationManager = new FigureCreationManager(figureCreators);
            var commandExecutors = new List<ICommandExecutor>
            {
                new CreateCommandExecutor(figuresStorage,figureCreationManager,logger),
                new PrintCommandExecutor(figuresStorage,logger),
                new ResetCommandExecutor(figuresStorage,logger),
                new ExitCommandExecutor()
            };

            var commandExecutionManager = new CommandExecutionManager(commandExecutors, logger);

            return new SurfaceAreaCalculator(commandExecutionManager, logger);
        }
    }
}
