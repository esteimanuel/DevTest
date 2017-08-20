// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// CreateShapeInputCommand.cs 
// 20 / 08 / 2017

using System.Collections.Generic;
using System.Linq;
using System.Text;
using Refactoring.DataModels.Shapes;
using Refactoring.Enums;
using Refactoring.Extensions;

namespace Refactoring.DataModels.Input
{
    public class CreateShapeInputCommand : InputCommand
    {
        public CreateShapeInputCommand(ShapeType type, params IInputParameter[] paramList) : base("create",
            type.GetDescription().ToLower(), GetDescription(type))
        {
            ShapeType = type;
            ParamList = paramList?.ToList() ?? new List<IInputParameter>();
        }

        public List<IInputParameter> ParamList { get; }
        public ShapeType ShapeType { get; }

        private static string GetDescription(ShapeType type)
        {
            return $"create a new {type.GetDescription()}";
        }

        public override string ToString()
        {
            var paramStringBuilder = new StringBuilder();
            ParamList.ForEach(inputParam => paramStringBuilder.Append($" {{{inputParam.ParameterDescription}}}"));

            return $"- {Keyword} {KeywordModifier}{paramStringBuilder} ({Description})";
        }

        public bool TrySetParameterValues(string[] arrCommands)
        {
            int startIndex = 2;
            if (ParamList.Count > arrCommands.Length - 2)
                return false;

            foreach (IInputParameter inputParameter in ParamList)
            {
                if (!inputParameter.SetValue(arrCommands[startIndex]))
                    return false;
                startIndex++;
            }

            return true;
        }
    }
}