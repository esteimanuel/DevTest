using System;

namespace Refactoring.Application.Extensions
{
    public static class StringArrayExtension
    {
        public static double? ParsePossibleDouble(this String[] strArr, int index)
        {
            try
            {
                if (Double.TryParse(strArr[index], out double value))
                    return value;

                return null;
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }
    }
}