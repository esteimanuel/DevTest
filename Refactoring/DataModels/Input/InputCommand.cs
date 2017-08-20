// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// InputCommand.cs 
// 20 / 08 / 2017

namespace Refactoring.DataModels.Input
{
    public class InputCommand : IInputCommand
    {
        public InputCommand(string keyword, string keywordModifier, string description)
        {
            Keyword = keyword;
            KeywordModifier = keywordModifier;
            Description = description;
        }

        public string Keyword { get; }
        public string KeywordModifier { get; set; }
        public string Description { get; }

        public override string ToString()
        {
            return $"- {Keyword} ({Description})";
        }
    }
}