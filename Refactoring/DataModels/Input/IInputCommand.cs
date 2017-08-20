// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// IInputCommand.cs 
// 20 / 08 / 2017

namespace Refactoring.DataModels.Input
{
    public interface IInputCommand
    {
        /// <summary>
        /// The keyword on which the command is ordered.
        /// </summary>
        string Keyword { get; }

        /// <summary>
        /// Keyword modifier which can be used if a command keyword is used multiple times.
        /// </summary>
        string KeywordModifier { get; }

        /// <summary>
        /// The global description for this command. Can be used to indicate te values for parameters.
        /// </summary>
        string Description { get; }
    }
}