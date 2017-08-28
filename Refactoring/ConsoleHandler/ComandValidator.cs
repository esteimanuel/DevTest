using System;
using Refactoring.Enums;
using Refactoring.Shapes;
using System.Globalization;
using Refactoring.Helper;
using Refactoring.DTO;

namespace Refactoring.ConsoleHandler
{
    public class ComandValidator : ShapeHelper
    {
        private string[] _actions = Enum.GetNames(typeof(Actions));
        private string[] _shapeTypes = Enum.GetNames(typeof(ShapeType));
        private static CultureInfo ci = new CultureInfo("en-US");

        public CurrentShape currentShape = new CurrentShape();

        public bool ValidComand(string inputComand)
        {
            if (String.IsNullOrEmpty(inputComand)) return false;

            var arrCommands = inputComand.Split(' ');

            var inputAction = arrCommands[0].ToLower().Trim();

            if (!ValidAction(inputAction)) return false;

            if (inputAction.ToLower() == Actions.Create.ToString().ToLower())
            {
                if (arrCommands.Length < 2)
                {
                    new Comand().Write("Missing shape!");
                    return false;
                }

                var inputShape = arrCommands[1].ToLower().Trim();

                if (!ValidShape(inputShape))
                {
                    new Comand().Write("Invalid shape!");
                    return false;
                }

                if (!ValidParams(arrCommands))
                {
                    new Comand().Write("Invalid params for shape or missing!");
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// Returns if part of comand for action is correct, should be one from  Enum Actions, if it is, sets as current Action
        /// </summary>
        private bool ValidAction(string inputAction)
        {
            bool validAction = false;
            foreach (var act in _actions)
            {
                if (act.ToLower().Equals(inputAction))
                {
                    validAction = true;
                    currentShape.Action = act;
                    break;
                }
            }

            return validAction;
        }

        /// <summary>
        /// Returns if part of comand for shape is correct, should be one from Enum ShapeType
        /// </summary>
        private bool ValidShape(string inputShape)
        {
            if (string.IsNullOrEmpty(inputShape)) return false;

            IShape shape = null;
            foreach (var sh in _shapeTypes)
            {
                inputShape = ci.TextInfo.ToTitleCase(inputShape);
                if (sh.Equals(inputShape))
                {
                    shape = GetShapeInstance(inputShape);
                    currentShape.Shape = shape;
                    break;
                }
            }
            return shape != null;
        }

        /// <summary>
        /// Returns if part of comand for params is correct, must be same number of params like in ListOfParams of that shape and must be double type
        /// </summary>
        private bool ValidParams(string[] arrCommands)
        {

            var currParams = currentShape.Shape.ShapeParamList;

            if ((arrCommands.Length < 3) ||
                arrCommands.Length - 2 != currParams.Count)
            {
                return false;
            }

            for (int i = 0; i < currParams.Count; i++)
            {
                double parValue;
                if (!double.TryParse(arrCommands[i + 2], out parValue)) return false;
                currParams[i].ParamValue = parValue;
            }

            return true;
        }
    }
}
