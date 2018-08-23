using System;
using System.Globalization;

namespace GS.Tools.Extensions
{
    public static class Numbers
    {
        #region Equivalent
        /// <summary>
        /// Check if two double numbers are equals considering precision
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public static bool Equivalent(this double d1, double d2, int precision = 2, EqualsTestMode mode = EqualsTestMode.Truncate)
        {
            int mult = (int)Math.Pow(10, precision);

            switch (mode)
            {
                case EqualsTestMode.Truncate:
                    return (int)Math.Truncate(d1 * mult) == (int)Math.Truncate(d2 * mult);
                case EqualsTestMode.Round:
                    return (int)Math.Round(d1 * mult) == (int)Math.Round(d2 * mult);
            }
            return false;
        }


        /// <summary>
        /// Check if two decimal numbers are equals considering precision
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <param name="precision"></param>
        /// <returns></returns>   
        public static bool Equivalent(this decimal d1, decimal d2, int precision = 2, EqualsTestMode mode = EqualsTestMode.Truncate)
        {
            int mult = (int)Math.Pow(10, precision);
            switch (mode)
            {
                case EqualsTestMode.Truncate:
                    return (int)Math.Truncate(d1 * mult) == (int)Math.Truncate(d2 * mult);
                case EqualsTestMode.Round:
                    return (int)Math.Round(d1 * mult) == (int)Math.Round(d2 * mult);
            }
            return false;
        }

        #endregion

        #region IsBetween
        /// <summary>
        /// Check if decimal number is in range
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static bool IsBetween(this decimal value, decimal minValue, decimal maxValue) =>
            value >= minValue && value <= maxValue;

        /// <summary>
        /// Check if double number is in range
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static bool IsBetween(this double value, double minValue, double maxValue) =>
            value >= minValue && value <= maxValue;

        /// <summary>
        /// Check if int number is in range
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static bool IsBetween(this int value, int minValue, int maxValue) =>
            value >= minValue && value <= maxValue;

        #endregion

        #region ForceInterval
        /// <summary>
        /// Force int value in interval
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int ForceInterval(this int value, int minValue, int maxValue) =>
            (minValue <= maxValue) ? (value < minValue) ? minValue : (value > maxValue) ? maxValue : value : value;

        /// <summary>
        /// Force double value in interval
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static double ForceInterval(this double value, double minValue, double maxValue) =>
            (minValue <= maxValue) ? (value < minValue) ? minValue : (value > maxValue) ? maxValue : value : value;

        /// <summary>
        /// Force decimal value in interval
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static decimal ForceInterval(this decimal value, decimal minValue, decimal maxValue) =>
            (minValue <= maxValue) ? (value < minValue) ? minValue : (value > maxValue) ? maxValue : value : value;


        #endregion

        #region IsZero
        /// <summary>
        /// Check if double value is about zero
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsZero(this double d) => Equivalent(d, 0);

        /// <summary>
        /// Check if decimal value is about zero
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsZero(this decimal d) => Equivalent(d, 0);
        #endregion

        #region ToBytes
        /// <summary>
        /// Format size to multiples of Byte
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToBytes(this long bytes)
        {
            string sufix = "B", format = "N1";
            double b = bytes;
            if (bytes >= 1099511627776)
            {
                sufix = "TB";
                b = (double)bytes / 1099511627776;
            }
            else if (bytes >= 1073741824)
            {
                sufix = "GB";
                b = (double)bytes / 1073741824;
            }
            else if (bytes >= 1048576)
            {
                sufix = "MB";
                b = (double)bytes / 1048576;
            }
            else if (bytes >= 1024)
            {
                sufix = "KB";
                b = (double)bytes / 1024;
            }
            else
                format = "N0";
            return b.ToString(format) + sufix;
        }

        public static string ToBytes(this int bytes) => ToBytes((long)bytes);

        #endregion

        #region ToInvariantString
        /// <summary>
        /// Returns double to string with invariant decimal separator
        /// </summary>
        /// <param name="valorDouble"></param>
        /// <returns></returns>
        public static string ToInvariantString(this double valorDouble) =>
            valorDouble.ToString(CultureInfo.InvariantCulture);

        /// <summary>
        /// Returns decimal to string with invariant decimal separator
        /// </summary>
        /// <param name="valorDouble"></param>
        /// <returns></returns>
        public static string ToInvariantString(this decimal valorDecimal) =>
            valorDecimal.ToString(CultureInfo.InvariantCulture);
        #endregion

        public enum EqualsTestMode
        {
            Truncate,
            Round
        }
    }
}
