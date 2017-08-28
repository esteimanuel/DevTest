using Refactoring.Enums;
using Refactoring.Helper;
using Refactoring.DTO;
using System;
using System.Collections.Generic;
using Refactoring.Shapes;

namespace Refactoring.ConsoleHandler
{
    public class ComandHandler : ConsoleAction
    {
        public CurrentShape currentShape;
        public List<IShape> _listOfShapes = new List<IShape>();
        public List<ShapeInfo> _listOfCalculatedAreas= new List<ShapeInfo>();
        private string[] _actions = Enum.GetNames(typeof(Actions));
        private string[] _shapeTypes = Enum.GetNames(typeof(ShapeType));
   
        public ComandHandler(IComand comand) : base(comand)
        {
        }

        public void Greeting()
        {
            _comand.Write(" -------------------------------------------------------------------------- ");
            _comand.Write("| Greetings and salutations fellow developer :D                            |");
            _comand.Write("|                                                                          |");
            _comand.Write("| If you are reading this we probably want to know if you know your stuff. |");
            _comand.Write("|                                                                          |");
            _comand.Write("| How would you improve this code?                                         |");
            _comand.Write("| We challenge you to refactor this and show us how awesome you are ;)     |");
            _comand.Write("| We also really like trapezoids so could you also implement that for us?  |");
            _comand.Write("|                                                                          |");
            _comand.Write("|                                                               Good luck! |");
            _comand.Write(" --------------------------------------------------------------------------");
        }

        public void ShowCommands(bool unknownInputComand)
        {
            if (unknownInputComand)
            {
                _comand.Write("Unknown command!!!");
            }

            _comand.Write("commands:");

            foreach (var action in _actions)
            {
                if (action.Equals(Actions.Create.ToString()))
                {
                    foreach (var shapeType in _shapeTypes)
                    {
                        CreateComandForAction(action, " " + shapeType);
                        WriteAction();
                    }
                    continue;
                }
                CreateComandForAction(action);
                WriteAction();
            }
        }

        public bool ExecuteInputComand()
        {
            var enumAction = (Actions)Enum.Parse(typeof(Actions), currentShape.Action);

            switch (enumAction)
            {
                case Actions.Create:
                    CreateShape();
                    break;
                case Actions.Calculate:
                    CalculateSurfaceAreas();
                    break;
                case Actions.Print:
                    PrintCalculatedShapes();
                    break;
                case Actions.Reset:
                    Reset();
                    break;
                case Actions.Exit:
                    return true;
                default:
                    ShowCommands(false);
                    break;
            }
            return false;
        }

        public void CreateShape()
        {
            var currShape = currentShape.Shape;
            _listOfShapes.Add(currShape);
            var shapeName = currShape.GetType().Name;
            _comand.Write(string.Format("{0} created!", shapeName));
        }

        public void CalculateSurfaceAreas()
        {
            _listOfCalculatedAreas.Clear();

            if (_listOfShapes.Count < 1) {
                _comand.Write("There is nothing to calculate. Please, first create shape(s).");
                return;
            }

            foreach (var shape in _listOfShapes)
            {
                _listOfCalculatedAreas.Add(new ShapeInfo
                {
                    ShapeName = shape.GetType().Name,
                    ShapeAreaSurface = shape.CalculateSurfaceArea()
                });
            }

            _comand.Write("calculated!!");
        }

        public void PrintCalculatedShapes()
        {
            if (_listOfCalculatedAreas.Count < 1)
                _comand.Write("There are no surface areas to print. Try to create shape and calculate first.");

            for (int i = 0; i < _listOfCalculatedAreas.Count; i++)
            {
                _comand.Write(string.Format("[{0}] {1} surface area is {2}", i, _listOfCalculatedAreas[i].ShapeName, _listOfCalculatedAreas[i].ShapeAreaSurface));

            }
        }

        public void Reset() {
            _listOfShapes.Clear();
            _listOfCalculatedAreas.Clear();
            _comand.Write("Reset state!!");
        }
    }
}