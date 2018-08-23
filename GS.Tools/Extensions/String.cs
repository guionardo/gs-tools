using System;
using System.Globalization;
using System.Text;

namespace GS.Tools.Extensions
{
    public static class String
    {
        /// <summary>
        /// Check if string has at least one of the itens
        /// </summary>
        /// <param name="text"></param>
        /// <param name="itens">itens</param>
        /// <param name="CaseInsensitive">Ignore case</param>
        /// <returns></returns>
        public static bool ContainsOne(this string text, string[] itens, bool CaseInsensitive = false)
        {
            if (itens == null || itens.Length == 0 || string.IsNullOrEmpty(text))
                return false;
            if (CaseInsensitive)
            {
                text = text.ToUpperInvariant();
                for (int i = 0; i < itens.Length; i++)
                    itens[i] = itens[i].ToUpperInvariant();
            }
            for (int i = 0; i < itens.Length; i++)
                if (text.Contains(itens[i]))
                    return true;

            return false;
        }

        /// <summary>
        /// Remove non-numeric characters from string
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        public static string JustNumbers(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return "";
            string s = "";
            for (int i = 0; i < text.Length; i++)
                if (text[i] >= '0' && text[i] <= '9')
                    s += text[i];
            return s;
        }

        /// <summary>
        /// Telephone number format (Brazil)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string PhoneNumber(this string text)
        {
            text = JustNumbers(text);
            if (string.IsNullOrEmpty(text)) return "";
            if (text.Length < 10)
                return string.Format("{0:0000-0000}", long.Parse(text));
            if (text.Length == 10)
                return string.Format("{0:(00)0000-0000}", long.Parse(text));
            return string.Format("{0:(00)00000-0000}", long.Parse(text));
        }

        /// <summary>
        /// Remove(replace) accents (diacritcs) from string
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        public static string RemoveAccents(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            return Encoding.UTF8.GetString(Encoding.GetEncoding("iso-8859-8").GetBytes(text));
        }
        /// <summary>
        /// Parse an string to Date, using various formats
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DateTime ToDate(this string text)
        {
            string[] formats = {
                "dd/MM/yyyy",
                "d/M/yyyy",
                "ddMMyyyy",
                "yyyy-MM-dd",
                "yyyyMMdd"
            };
            DateTime.TryParseExact(text, formats,
                new CultureInfo("pt-BR"),
                DateTimeStyles.None,
                out DateTime dt);
            return dt.Date;
        }

        /// <summary>
        /// Parse an string to DateTime, using various formats
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string text)
        {
            string[] formats =
            {
                "dd/MM/yyyy",
                "d/M/yyyy",
                "ddMMyyyy",
                "yyyy-MM-dd",
                "yyyy-MM-dd HH:mm:ss",
                "HH:mm:ss",
                "HH:mm",
                "h:m",
                "yyyyMMddHHmmss",
                "dd/MM/yyyy HH:mm:ss"
            };

            DateTime.TryParseExact(text, formats,
                new CultureInfo("pt-BR"),
                DateTimeStyles.None,
                out DateTime dt);
            return dt;
        }

        /// <summary>
        /// Convert string to decimal checking for decimal point
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string text)
        {
            decimal d;
            if (text.Contains(NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator))
                decimal.TryParse(text, NumberStyles.Any, NumberFormatInfo.CurrentInfo, out d);
            else
                decimal.TryParse(text, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out d);
            return d;
        }

        /// <summary>
        /// Convert string to double checking for decimal point
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static double ToDouble(this string text)
        {
            double d;
            if (text.Contains(NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator))
                double.TryParse(text, NumberStyles.Any, NumberFormatInfo.CurrentInfo, out d);
            else
                double.TryParse(text, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out d);
            return d;
        }

        /// <summary>
        /// Parse text to int
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToInt(this string text, int defaultValue = 0)
        {
            if (!int.TryParse(text, out int i))
                i = defaultValue;
            return i;
        }

        /// <summary>
        /// Convert string to Time (DateTime)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DateTime ToTime(this string text)
        {
            string[] formats =
            {
                "HH:mm:ss",
                "HH:mm",
                "h:m",
            };

            DateTime.TryParseExact(text, formats,
                new CultureInfo("pt-BR"),
                DateTimeStyles.None,
                out DateTime dt);
            return dt;
        }
    }
}
