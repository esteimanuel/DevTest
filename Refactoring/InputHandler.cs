// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// InputHandler.cs 
// 20 / 08 / 2017

using System.Collections.Generic;
using System.Linq;
using Refactoring.DataModels.Input;
using Refactoring.DataModels.Logging;

namespace Refactoring
{
    public class InputHandler
    {
        private readonly List<IInputCommand> _availableCommands;
        private readonly ILogger _logger;

        public InputHandler(ILogger log, List<IInputCommand> availableCommands)
        {
            _logger = log;
            _availableCommands = availableCommands;
        }

        public void ShowCommands()
        {
            _logger.Log("commands:");
            _availableCommands.ForEach(command => _logger.Log(command.ToString()));
        }

        public IInputCommand ParseCommand(string pCommand)
        {
            if (string.IsNullOrEmpty(pCommand))
                return null;

            string[] arrCommands = pCommand.Split(' ');
            if (arrCommands.Length == 0)
                return null;

            if (arrCommands[0].ToLower().Equals("create"))
                return arrCommands.Length > 1 ? ParseCreateCommand(arrCommands) : null;

            IInputCommand enteredCommand =
                _availableCommands.FirstOrDefault(command => command.Keyword.Equals(arrCommands[0]));
            return enteredCommand;
        }

        private IInputCommand ParseCreateCommand(string[] arrCommands)
        {
            string shapeName = arrCommands[1].ToLower();

            IInputCommand shape =
                _availableCommands.FirstOrDefault(command => command.KeywordModifier.Equals(shapeName));
            CreateShapeInputCommand shapeInputCommand = shape as CreateShapeInputCommand;
            if (shapeInputCommand == null)
                return null;

            return shapeInputCommand.TrySetParameterValues(arrCommands) ? shapeInputCommand : null;
        }
    }
}