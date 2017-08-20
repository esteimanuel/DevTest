// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// Logger.cs 
// 20 / 08 / 2017

using System;

namespace Refactoring
{
    internal class Logger : ILogger
    {
        public void Log(string pLog)
        {
            Console.WriteLine(pLog);
        }
    }
}