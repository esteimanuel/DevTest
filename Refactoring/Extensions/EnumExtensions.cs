// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// EnumExtensions.cs 
// 20 / 08 / 2017

using System;
using System.ComponentModel;
using System.Reflection;

namespace Refactoring.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Returns the value indicated by the 'Description' decorator
        /// </summary>
        public static string GetDescription(this Enum enummeration)
        {
            FieldInfo fi = enummeration.GetType().GetField(enummeration.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[]) fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : enummeration.ToString();
        }
    }
}