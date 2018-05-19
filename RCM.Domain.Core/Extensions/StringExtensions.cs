using System;

namespace RCM.Domain.Core.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Convert a string into a DateTime? and return 
        /// </summary>
        /// <param name="dateString">String to Convert</param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this string dateString)
        {
            if (dateString == null) return null;
            DateTime.TryParse(dateString, out DateTime date);

            return date;
        }

        /// <summary>
        /// Convert a string into a DateTime? and return Date Object
        /// </summary>
        /// <param name="dateString">String to Convert</param>
        /// <returns></returns>
        public static DateTime? ToDate(this string dateString)
        {
            if (dateString == null) return null;
            DateTime.TryParse(dateString, out DateTime date);
            
            return DateTime.Parse(date.ToShortDateString());
        }

        /// <summary>
        /// Convert a string into a Decimal and return decimal? 
        /// </summary>
        /// <param name="decimalString">String to Convert</param>
        /// <returns></returns>
        public static decimal? ToDecimal(this string decimalString)
        {
            if (decimalString == null) return null;
            Decimal.TryParse(decimalString, out decimal value);

            return value;
        }
    }
}
