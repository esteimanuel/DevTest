using Refactoring.ConsoleHandler;
using Refactoring.Helper;

namespace Refactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            Comand comand = new Comand();
            ComandValidator validator = new ComandValidator();
            ComandHandler handler = new ComandHandler(comand);

            handler.Greeting();
            handler.ShowCommands(false);

            var exit = false;
            do
            {
                var inputCommand = comand.ReadLine();

                if (validator.ValidComand(inputCommand)) { 
                    handler.currentShape = validator.currentShape;
                    exit = handler.ExecuteInputComand();
                }
                else
                {
                    handler.ShowCommands(true);
                }
            }
            while (!exit);

            comand.ReadKey();

        }
    }
}

