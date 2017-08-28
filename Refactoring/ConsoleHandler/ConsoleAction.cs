using Refactoring.DTO;
using Refactoring.Enums;
using Refactoring.Helper;
using System;
using System.Collections.Generic;

namespace Refactoring.ConsoleHandler
{
    public class ConsoleAction
    {
        public IComand _comand;

        private string _action;
        private string _params;
        private string _description;

        public ConsoleAction(IComand comand)
        {
            _comand = comand;
        }

        public void CreateComandForAction(string action, string shapeType = "")
        {
            _action = string.Format("- {0}{1}", action.ToLower(), shapeType.ToLower());

            _description = EnumHelper.GetDescription((Actions)Enum.Parse(typeof(Actions), action));
            _description = string.Format("({0}{1})", _description, shapeType.ToLower());

            _params = " ";

            if (!string.IsNullOrEmpty(shapeType))
            {
                var helper = new ShapeHelper();
                var shapeInstance = helper.GetShapeInstance(shapeType);
                if (shapeInstance != null)
                {
                    var shapeParamList = (List<ShapeParam>)(helper.GetPropValue(shapeInstance, "ShapeParamList"));
                    foreach (var item in shapeParamList)
                    {
                        var param = string.Format("{{{0}}} ", item.ParamName.ToLower());
                        _params += param;
                    }
                }
            }
        }

        public void WriteAction()
        {
            new Comand().Write(_action + _params + _description);
        }
    }
}
