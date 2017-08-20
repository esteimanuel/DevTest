// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// InputParameter.cs 
// 20 / 08 / 2017

using System;
using System.Globalization;

namespace Refactoring.DataModels.Input
{
    public class InputParameter<T> : IInputParameter
    {
        public InputParameter(string parameterDescription)
        {
            ParameterDescription = parameterDescription;
        }

        public T Value { get; private set; }
        public string ParameterDescription { get; }

        public bool SetValue(string unparsedValue)
        {
            try
            {
                Value = (T) Convert.ChangeType(unparsedValue, typeof(T), CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                return false; // unable to parse I guess..
            }
            return true;
        }
    }
}