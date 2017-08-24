using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Refactoring
{
    class Program
    {
        static void Main(string [] args)
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
        public string currentNamespace { get; private set; }
        public List<Shape> ShapesArr { get; set; }
        public List<string> ParamsList { get;  set; }
        public double [] SurfaceAreasArr { get; set; }
        public Dictionary<int, Shape> ShapesAreasArr { get; set; }

        internal Logger Logger { get; private set; }

        public SurfaceAreaCalculator()
        {
            this.Logger = new Logger();
            currentNamespace = this.GetType().Namespace;
            ParamsList = new List<string>();
            ShapesArr = new List<Shape>();
            ShapesAreasArr = new Dictionary<int, Shape>();
        }

        public void ShowCommands()
        {
            this.Logger.Log("commands:");
            this.Logger.Log("- create square {double} (create a new square)");
            this.Logger.Log("- create circle {double} (create a new circle)");
            this.Logger.Log("- create rectangle {height} {width} (create a new rectangle)");
            this.Logger.Log("- create triangle {height} {width} (create a new triangle)");
            this.Logger.Log("- create trapezoid {topSide} {bottomSide} {height} (create a new trapezoid)");
            this.Logger.Log("- print (print the calculated surface areas)");
            this.Logger.Log("- calculate (calulate the surface areas of the created shapes)");
            this.Logger.Log("- reset (reset)");
            this.Logger.Log("- exit (exit the loop)");
        }
        public void ShowError() {
            this.Logger.Log("Unknown command!!!");
        }

        public void Add(object pObject)
        {
            ShapesArr.Add((Shape) pObject);
        }

        public void ReadString(string pCommand)
        {
            try
            {
                string [] arrCommands = pCommand.ToLower().Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string command = "";
                ParamsList.Clear();
               
                foreach(string str in arrCommands)
                {
                    if(command == "")
                    {
                        command = Char.ToUpper(str [0]) + str.Substring(1);
                    } else
                    {
                        ParamsList.Add(str);
                    }
                }

                MethodInfo act = this.GetType().GetMethod(command);

                act.Invoke(this, null);
                
            }
            catch
            {
                ShowError();
                ShowCommands();
                this.ReadString(Console.ReadLine());
            }
        }

        public double GetDecimal(string str)
        {
            try
            {
                var strTrimmed = Regex.Split(str, @"[^0-9\.]+").Where(c => c != "." && c.Trim() != "").ToList() [0];
                return double.Parse(strTrimmed.Replace(".", ","));
            }
            catch
            {
                return 0;
            }
        }

        public void Create()
        {
            try
            {
                string shapeToCreate = "";

                foreach(string str in ParamsList)
                {
                    shapeToCreate = Char.ToUpper(str [0]) + str.Substring(1);
                    ParamsList.Remove(str);

                    break;
                }

                Type shape = Type.GetType(currentNamespace + "." + shapeToCreate);

                var newShapeCtorParams = shape.GetConstructors() [0].GetParameters();
                object [] paramsArr = new Object [newShapeCtorParams.Count()];
                var trimmed = ParamsList.GetRange(0, newShapeCtorParams.Count());

                for(int i = 0; i < paramsArr.Length; i++)
                {
                    paramsArr [i] = GetDecimal( trimmed [i]);
                }

                object newShape = Activator.CreateInstance(shape, paramsArr);
                this.Add(newShape);
                Console.WriteLine(shapeToCreate + " created!");
                this.ReadString(Console.ReadLine());
            }
            catch(Exception e)
            {
                ShowError();
                ShowCommands();
                this.ReadString(Console.ReadLine());
            }

        }
        public void Print()
        {
            int index = 0;
            foreach(var elem in ShapesAreasArr)
            {
                Console.WriteLine("[{0}] {1} surface area is {2}", elem.Key, elem.Value.GetType().Name, elem.Value.CalculatedSurfaceArea);
                index++;
            }
            if(ShapesAreasArr.Count() == 0)
            {
                Console.WriteLine("There are no surface areas to print.");
            }
        }
        public void Calculate()
        {
            ShapesAreasArr.Clear();

            int count = ShapesAreasArr.Count() > 0 ? ShapesAreasArr.Count() - 1 : ShapesAreasArr.Count();
            foreach(var obj in ShapesArr)
            {
                ShapesAreasArr.Add(count, obj);
                count++;
            }
            if(ShapesArr.Count() == 0)
            {
                Console.WriteLine("There are no surfaces to calculate.");
            }
        }

        public void Reset()
        {
            ShapesArr.Clear();
            ShapesAreasArr.Clear();
            ParamsList.Clear();

            Console.WriteLine("Reset state!!");
        }
        public void Exit()
        {
            Environment.Exit(0);
        }
    }

    internal class Logger
    {
        public void Log(string pLog)
        {
            Console.WriteLine(pLog);
        }
    }

    public abstract class Shape
    {
        public abstract double CalculatedSurfaceArea { get; }
        public static double GetSurfaceArea(Shape shape)
        {
            return shape.CalculatedSurfaceArea;
        }
       
    }

    public class Circle : Shape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculatedSurfaceArea
        {
            get {
                return Math.Round(Math.PI * (Radius * Radius), 2);
            }

        }

    }

    public class Rectangle : Shape
    {
        public double Height { get; }
        public double Width { get; }
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }
        public override double CalculatedSurfaceArea
        {
            get {
                return Height * Width;
            }
        }
    }

    public class Square : Shape
    {
        public double Side { get; }
        public Square(double side)
        {
            Side = side;
        }
        public override double CalculatedSurfaceArea
        {
            get {
                return Side * Side;
            }
        }
    }

    public class Triangle : Shape
    {
        public double Height { get; }
        public double Width { get; }

        public Triangle(double height,double width)
        {
            Height =  height;
            Width = width;
                
        }

        public override double CalculatedSurfaceArea
        {
            get {
                return 0.5 * (Height * Width);
            }
        }

    }

    public class Trapezoid : Shape
    {
        public double BaseA { get; }
        public double BaseB { get; }
        public double Height { get; }

        public Trapezoid(double sideA, double sideB, double height)
        {
            BaseA = sideA;
            BaseB = sideB;
            Height = height;

        }

        public override double CalculatedSurfaceArea
        {
            get {
                return 0.5 * (BaseA + BaseB) * Height;
            }
        }

    }
}