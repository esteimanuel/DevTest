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
            SurfaceAreaCalculator surfaceAreaCalculator = new SurfaceAreaCalculator();
            surfaceAreaCalculator.ShowCommands();
            surfaceAreaCalculator.ReadString(Console.ReadLine());
            Console.ReadKey();
        }
    }

    public class SurfaceAreaCalculator
    {
        public SurfaceAreaCalculator()
        {
            Logger = new Logger();
            _createdShapes = new List<IShape>();
        }

        public double[] ArrSurfaceAreas => _createdShapes.Select(shape => shape.CalculateSurfaceArea()).ToArray();
        private readonly List<IShape> _createdShapes;
        internal Logger Logger { get; }

        public void ShowCommands()
        {
            Logger.Log("commands:");
            Logger.Log("- create square {double} (create a new square)");
            Logger.Log("- create circle {double} (create a new circle)");
            Logger.Log("- create rectangle {height} {width} (create a new rectangle)");
            Logger.Log("- create triangle {height} {width} (create a new triangle)");
            Logger.Log("- print (print the calculated surface areas)");
            Logger.Log("- calculate (calulate the surface areas of the created shapes)");
            Logger.Log("- reset (reset)");
            Logger.Log("- exit (exit the loop)");
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
                                Console.WriteLine("{0} created!", square.GetType().Name);
                                break;
                            case "circle":
                                Circle circle = new Circle();
                                circle.Radius = double.Parse(arrCommands[2]);
                                Add(circle);
                                CalculateSurfaceAreas();
                                Console.WriteLine("{0} created!", circle.GetType().Name);
                                break;
                            case "triangle":
                                Triangle triangle = new Triangle();
                                triangle.Height = double.Parse(arrCommands[2]);
                                triangle.Width = double.Parse(arrCommands[3]);
                                Add(triangle);
                                CalculateSurfaceAreas();
                                Console.WriteLine("{0} created!", triangle.GetType().Name);
                                break;
                            case "rectangle":
                                Rectangle rectangle = new Rectangle();
                                rectangle.Height = double.Parse(arrCommands[2]);
                                rectangle.Width = double.Parse(arrCommands[3]);
                                Add(rectangle);
                                CalculateSurfaceAreas();
                                Console.WriteLine("{0} created!", rectangle.GetType().Name);
                                break;
                            default:
                                goto ShowCommands;
                        }
                    else
                        ShowCommands();
                    ReadString(Console.ReadLine());
                    break;
                case "calculate":
                    CalculateSurfaceAreas();
                    ReadString(Console.ReadLine());
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
                    Console.WriteLine("Reset state!!");
                    ReadString(Console.ReadLine());
                    break;
                case "exit":
                    break;
                default:
                    ShowCommands:
                    Logger.Log("Unknown command!!!");
                    Logger.Log("commands:");
                    Logger.Log("- create square {double} (create a new square)");
                    Logger.Log("- create circle {double} (create a new circle)");
                    Logger.Log("- create rectangle {height} {width} (create a new rectangle)");
                    Logger.Log("- create triangle {height} {width} (create a new triangle)");
                    Logger.Log("- print (print the calculated surface areas)");
                    Logger.Log("- calculate (calulate the surface areas of the created shapes)");
                    Logger.Log("- reset (reset)");
                    Logger.Log("- exit (exit the loop)");
                    ReadString(Console.ReadLine());
                    break;
            }
        }

        public void CalculateSurfaceAreas()
        {
            if (!_createdShapes.Any())
            {
                Logger.Log("arrItems is null or empty!!");
            }
            _createdShapes.ForEach(shape => shape.CalculateSurfaceArea());
        }
    }

    internal class Logger
    {
        public void Log(string pLog)
        {
            Console.WriteLine(pLog);
        }
    }
}