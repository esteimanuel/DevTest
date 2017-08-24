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
        object [] arrObjects { get; set; }
        public double [] arrSurfaceAreas { get; set; }
        public string currentNamespace;
        public List<Shape>  ShapesArr { get; set; }
        public List<string> ParamsList;
        public double [] SurfaceAreasArr { get; set; }
        Dictionary<string, double> shapesAreas;


        internal Logger Logger { get; private set; }

        public SurfaceAreaCalculator()
        {
            this.Logger = new Logger();
            currentNamespace = this.GetType().Namespace;
            ParamsList = new List<string>();
            ShapesArr = new List<Shape>();
            shapesAreas = new Dictionary<string, double>();
        }

        public void ShowCommands()
        {
            this.Logger.Log("commands:");
            this.Logger.Log("- create square {double} (create a new square)");
            this.Logger.Log("- create circle {double} (create a new circle)");
            this.Logger.Log("- create rectangle {height} {width} (create a new rectangle)");
            this.Logger.Log("- create triangle {height} {width} (create a new triangle)");
            this.Logger.Log("- print (print the calculated surface areas)");
            this.Logger.Log("- calculate (calulate the surface areas of the created shapes)");
            this.Logger.Log("- reset (reset)");
            this.Logger.Log("- exit (exit the loop)");
        }

        public void Add(object pObject)
        {

            ShapesArr.Add((Shape)pObject);

            object [] arrObjects2;
            if(this.arrObjects == null)
            {
                this.arrObjects = new object [1];
                if(this.arrObjects != null)
                {
                    this.arrObjects [0] = pObject;
                }
            } else
            {
                if(this.arrObjects != null)
                {
                    arrObjects2 = new object [this.arrObjects.Length + 1];
                    int i;
                    for(i = 0; i < arrObjects2.Length; i++)
                    {
                        if(i == arrObjects2.Length - 1)
                        {
                            arrObjects2 [i] = pObject;
                        } else
                        {
                            arrObjects2 [i] = this.arrObjects [i];
                        }
                    }
                    this.arrObjects = arrObjects2;
                }
            }
        }


        public void ReadString(string pCommand)
        {
            string [] arrCommands = pCommand.ToLower().Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            // todo show commands if empty string
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

            // Methods methods = new Methods();
            MethodInfo act = this.GetType().GetMethod(command);

            // TODO if no action - return
            if(act != null)
                act.Invoke(this, null);

            this.ReadString(Console.ReadLine());

            string verb = arrCommands [0].ToLower();

            switch(verb)
            {
               
                //case "calculate":
                //    this.CalculateSurfaceAreas();
                //    this.ReadString(Console.ReadLine());
                //    break;
                case "print":
                    if(arrSurfaceAreas != null)
                    {
                        for(int i = 0; i < arrSurfaceAreas.Length; i++)
                        {
                            Console.WriteLine("[{0}] {1} surface area is {2}", i, arrObjects [i].GetType().Name, arrSurfaceAreas [i]);
                        }
                    } else
                    {
                        Console.WriteLine("There are no surface areas to print");
                    }
                    this.ReadString(Console.ReadLine());
                    break;
                case "reset":
                    this.arrSurfaceAreas = null;
                    this.arrObjects = null;
                    Console.WriteLine("Reset state!!");
                    this.ReadString(Console.ReadLine());
                    break;
                case "exit":
                    break;
                default:
                    ShowCommands:
                    this.Logger.Log("Unknown command!!!");
                    ShowCommands();
                    this.ReadString(Console.ReadLine());
                    break;
            }
        }
        // create shape
        public void Create()
        {
            try
            {
                Console.WriteLine("CREATE!");
                string shapeToCreate = "";

                foreach(string str in ParamsList)
                {
                    shapeToCreate = Char.ToUpper(str [0]) + str.Substring(1);
                    ParamsList.Remove(str);
                    Console.WriteLine("Run in a loop!");
                    break;
                }

                Type shape = Type.GetType(currentNamespace + "." + shapeToCreate);

                var newShapeCtorParams = shape.GetConstructors() [0].GetParameters();
                object [] paramsArr = new Object [newShapeCtorParams.Count()];
                var trimmed = ParamsList.GetRange(0,newShapeCtorParams.Count());

                for(int i = 0; i < paramsArr.Length; i++)
                {
                    paramsArr [i] = trimmed [i];
                }

               object newShape = Activator.CreateInstance(shape,paramsArr);
                this.Add(newShape);
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR IN CREATE");
                // SHOW COMMANDS();
            }
        }
        public void Print()
        {
            Console.WriteLine("PRINT!");
            foreach(var elem in shapesAreas)
            //for(int i = 0; i < shapesAreas.Count(); i++)
            {
                //  var elem = shapesAreas [i];
             //   Console.WriteLine("[{0}] {1} surface area is {2}", i, elem.Key, elem.Value);

            }
           

        }
        public void Calculate()
        {
            Console.WriteLine("CALCULATE!");
            foreach(var obj in ShapesArr)
            {
                shapesAreas.Add(obj.GetType().Name, obj.CalculatedSurfaceArea);
            }
        }

        public void Reset()
        {
            this.arrSurfaceAreas = null;
            this.arrObjects = null;
            // empty paramsList 
            Console.WriteLine("Reset state!!");
            // this.ReadString(Console.ReadLine());
        }
        public void Exit()
        {
            Console.WriteLine("EXIT!");
        }

        public void CalculateSurfaceAreas()
        {
            //try
            //{
            //    if(this.arrObjects != null)
            //    {
            //        this.arrSurfaceAreas = new double [this.arrObjects.Length];
            //        for(int i = 0; i < this.arrObjects.Length; i++)
            //        {
            //            if(this.arrObjects [i].GetType().Name == "Circle")
            //            {
            //                this.arrSurfaceAreas [i] = ((Circle) this.arrObjects [i]).CalculateSurfaceArea();
            //            } else
            //            {
            //                if(this.arrObjects [i].GetType().Name == "Rectangle")
            //                {
            //                    this.arrSurfaceAreas [i] = ((Rectangle) this.arrObjects [i]).CalculateSurfaceArea();
            //                } else
            //                {
            //                    if(this.arrObjects [i].GetType().Name == "Square")
            //                    {
            //                        this.arrSurfaceAreas [i] = ((Square) this.arrObjects [i]).CalculateSurfaceArea();
            //                    } else
            //                    {
            //                        if(this.arrObjects [i].GetType().Name == "Triangle")
            //                        {
            //                            this.arrSurfaceAreas [i] = ((Triangle) this.arrObjects [i]).CalculateSurfaceArea();
            //                        } else
            //                        {
            //                            throw new Exception("Cannot calculate surface area of unkown object!!!");
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    } else if(this.arrObjects == null)
            //    {
            //        throw new Exception("arrItems is null!!");
            //    }

            //}
            //catch(Exception ex)
            //{
            //    this.Logger.Log(ex.ToString());
            //    this.arrObjects = new object [0];
            //}
        }

        //public double GetDecimal(string str) {
        //    string strTrimmed = Regex.Split(str, @"[^0-9\.]+").Where(c => c != "." && c.Trim() != "").ToString();
        //    return double.Parse(strTrimmed);


        //}
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
        public virtual double GetDecimal(string str)
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
    }

    public class Circle : Shape
    {
        public double Radius { get; }

        //public Circle(List<string> paramsList)
        //{
        //    foreach(string str in paramsList)
        //    {
        //        Radius = GetDecimal(str);
        //        break;
        //    }
        //    Console.WriteLine("Circle");
        //}
        public Circle(string param)
        {
            Radius = GetDecimal(param);
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
        //public Rectangle(List<string> strings)
        //{
        //    Console.WriteLine("Rectangle");
        //    for(int i = 0; i < strings.Count(); i++)
        //    {
        //        Height = GetDecimal(strings [0]);

        //    }
        //}
        public Rectangle(string height, string width)
        {
            Height = GetDecimal( height);
            Width = GetDecimal( width);
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
        //public Square(double side)
        //{
        //    Side = side;
        //}
        public Square(List<string> strings)
        {
            Console.WriteLine("Square");
        }
        public override double CalculatedSurfaceArea
        {
            get {
                return Math.Sqrt(Side);
            }
        }
    }

    public class Triangle : Shape
    {
        public double Height { get; }
        public double Width { get; }

        //public Triangle(double height, double width)
        //{
        //    Height = height;
        //    Width = width;
        //}
        public Triangle(List<string> strings)
        {
            Console.WriteLine("Triangle");
        }

        public override double CalculatedSurfaceArea
        {
            get {
                return 0.5 * (Height * Width);
            }
        }

        //public double CalculateSurfaceArea()
        //{
        //    return 0.5 * (this.height * this.width);
        //}
    }

    public class Trapeziod : Shape
    {
        public double BaseA { get; }
        public double BaseB { get; }
        public double Height { get; }

        //public Trapeziod(double a, double b, double height)
        //{
        //    BaseA = a;
        //    BaseB = b;
        //    Height = height;
        //}
        public Trapeziod(List<string> strings)
        {
            Console.WriteLine("Trapeziod");
        }

        public override double CalculatedSurfaceArea
        {
            get {
                return 0.5 * (BaseA + BaseB) * Height;
            }
        }
    }
}