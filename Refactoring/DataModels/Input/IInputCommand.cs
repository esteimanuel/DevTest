// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// IInputCommand.cs 
// 20 / 08 / 2017

namespace Refactoring.DataModels.Input
{
    public interface IInputCommand
    {
        string Keyword { get; }
        string KeywordModifier { get; }
        string Description { get; }
    }
}