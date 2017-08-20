// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// Program.cs 
// 20 / 08 / 2017

using System;
using System.Collections.Generic;
using System.Linq;
using Refactoring.Shapes;

namespace Refactoring
{
    internal class Program
    {
        private static void Main(string[] args)
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

            ILogger consoleLogger = new Logger();
            SurfaceAreaCalculator surfaceAreaCalculator = new SurfaceAreaCalculator(consoleLogger);
            surfaceAreaCalculator.ShowCommands();
            surfaceAreaCalculator.ReadString(Console.ReadLine());
            Console.ReadKey();
        }
    }

    public class SurfaceAreaCalculator
    {
        public double[] ArrSurfaceAreas => _createdShapes.Select(shape => shape.CalculateSurfaceArea()).ToArray();
        private readonly List<IShape> _createdShapes;
        private readonly ILogger _logger;
        
        public SurfaceAreaCalculator(ILogger logger)
        {
            _logger = logger;
            _createdShapes = new List<IShape>();
        }

        public void ShowCommands()
        {
            _logger.Log("commands:");
            _logger.Log("- create square {double} (create a new square)");
            _logger.Log("- create circle {double} (create a new circle)");
            _logger.Log("- create rectangle {height} {width} (create a new rectangle)");
            _logger.Log("- create triangle {height} {width} (create a new triangle)");
            _logger.Log("- print (print the calculated surface areas)");
            _logger.Log("- calculate (calulate the surface areas of the created shapes)");
            _logger.Log("- reset (reset)");
            _logger.Log("- exit (exit the loop)");
        }

        public void Add(IShape shapeObject) => _createdShapes.Add(shapeObject);

        public void ReadString(string pCommand)
        {
            string[] arrCommands = pCommand.Split(' ');
            switch (arrCommands[0].ToLower())
            {
                case "create":
                    if (arrCommands.Length > 1)
                        switch (arrCommands[1].ToLower())
                        {
                            case "square":
                                Square square = new Square();
                                square.Side = double.Parse(arrCommands[2]);
                                Add(square);
                                CalculateSurfaceAreas();
                                _logger.Log($"{square.GetType().Name} created!");
                                break;
                            case "circle":
                                Circle circle = new Circle();
                                circle.Radius = double.Parse(arrCommands[2]);
                                Add(circle);
                                CalculateSurfaceAreas();
                                _logger.Log($"{circle.GetType().Name} created!");
                                break;
                            case "triangle":
                                Triangle triangle = new Triangle();
                                triangle.Height = double.Parse(arrCommands[2]);
                                triangle.Width = double.Parse(arrCommands[3]);
                                Add(triangle);
                                CalculateSurfaceAreas();
                                _logger.Log($"{triangle.GetType().Name} created!");
                                break;
                            case "rectangle":
                                Rectangle rectangle = new Rectangle();
                                rectangle.Height = double.Parse(arrCommands[2]);
                                rectangle.Width = double.Parse(arrCommands[3]);
                                Add(rectangle);
                                CalculateSurfaceAreas();
                                _logger.Log($"{rectangle.GetType().Name} created!");
                                break;
                            default:
                                goto ShowCommands;
                        }
                    else
                    ShowCommands();
                    //ReadString(Console.ReadLine());
                    break;
                case "calculate":
                    CalculateSurfaceAreas();
                    //ReadString(Console.ReadLine());
                    break;
                //case "print":
                //    if (ArrSurfaceAreas != null)
                //        for (int i = 0; i < ArrSurfaceAreas.Length; i++)
                //            Console.WriteLine("[{0}] {1} surface area is {2}", i, arrObjects[i].GetType().Name,
                //                ArrSurfaceAreas[i]);
                //    else
                //        Console.WriteLine("There are no surface areas to print");
                //    ReadString(Console.ReadLine());
                //    break;
                case "reset":
                    _createdShapes.Clear();
                    _logger.Log("Reset state!!");
                    //ReadString(Console.ReadLine());
                    break;
                case "exit":
                    break;
                default:
                    ShowCommands:
                    _logger.Log("Unknown command!!!");
                    _logger.Log("commands:");
                    _logger.Log("- create square {double} (create a new square)");
                    _logger.Log("- create circle {double} (create a new circle)");
                    _logger.Log("- create rectangle {height} {width} (create a new rectangle)");
                    _logger.Log("- create triangle {height} {width} (create a new triangle)");
                    _logger.Log("- print (print the calculated surface areas)");
                    _logger.Log("- calculate (calulate the surface areas of the created shapes)");
                    _logger.Log("- reset (reset)");
                    _logger.Log("- exit (exit the loop)");
                    //ReadString(Console.ReadLine());
                    break;
            }
        }

        public void CalculateSurfaceAreas()
        {
            if (!_createdShapes.Any())
            {
                _logger.Log("arrItems is null or empty!!");
            }
            _createdShapes.ForEach(shape => shape.CalculateSurfaceArea());
        }
    }
}