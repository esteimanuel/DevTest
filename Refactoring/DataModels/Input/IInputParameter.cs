// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// IInputParameter.cs 
// 20 / 08 / 2017

namespace Refactoring.DataModels.Input
{
    public interface IInputParameter
    {
        string ParameterDescription { get; }
        bool SetValue(string unparsedValue);
    }
}