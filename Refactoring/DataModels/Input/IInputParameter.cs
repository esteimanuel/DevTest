// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// IInputParameter.cs 
// 20 / 08 / 2017

namespace Refactoring.DataModels.Input
{
    public interface IInputParameter
    {
        /// <summary>
        /// The description for this parameter. Will be shown when printing the command.
        /// </summary>
        string ParameterDescription { get; }

        /// <summary>
        /// Tries to convert the provided string to the value assigned to this parameter. Returns false when the conversion failed. 
        /// </summary>
        bool SetValue(string unparsedValue);
    }
}