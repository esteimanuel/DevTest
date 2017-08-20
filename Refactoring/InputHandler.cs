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

        /// <summary>
        /// Writes the currently available commands to the logger.
        /// </summary>
        public void ShowCommands()
        {
            _logger.Log("commands:");
            _availableCommands.ForEach(command => _logger.Log(command.ToString()));
        }

        /// <summary>
        /// Tries to parse an IInputcommand from the provided string. Returns null if the input cannot be parsed.
        /// </summary>
        public IInputCommand ParseCommand(string pCommand)
        {
            if (string.IsNullOrEmpty(pCommand))
            {
                return null;
            }

            string[] arrCommands = pCommand.Split(' ');
            if (arrCommands.Length == 0)
            {
                return null;
            }
            string commandKeyword = arrCommands[0].ToLower();
            if (commandKeyword.Equals("create"))
            {
                return arrCommands.Length > 1 ? ParseCreateShapeCommand(arrCommands) : null;
            }

            IInputCommand enteredCommand = 
                _availableCommands.FirstOrDefault(command => command.Keyword.Equals(commandKeyword));
            return enteredCommand;
        }

        /// <summary>
        /// Tries to parse an IInputcommand from splitted console commands. Returns null if the command cannot be parsed (e.g. when the parameter values cannot be properly parsed)
        /// </summary>
        private IInputCommand ParseCreateShapeCommand(string[] arrCommands)
        {
            string shapeName = arrCommands[1].ToLower();

            IInputCommand shape = _availableCommands.FirstOrDefault(command => command.KeywordModifier.Equals(shapeName));
            CreateShapeInputCommand shapeInputCommand = shape as CreateShapeInputCommand;
            if (shapeInputCommand == null)
            {
                return null;
            }


            return shapeInputCommand.TrySetParameterValues(arrCommands) ? shapeInputCommand : null;
        }
    }
}