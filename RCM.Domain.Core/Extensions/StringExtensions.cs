using System;

namespace RCM.Domain.Core.Extensions
{
    public static class StringExtensions
    {
        //Workaround for ASP.NET Core Date Binding Error 
        //will be replaced later
        public static DateTime? ToDateTime(this string dateString)
        {
            if (dateString == null) return null;

            DateTime date;
            DateTime.TryParse(dateString, out date);

            return date;
        }

        public static DateTime? ToDate(this string dateString)
        {
            if (dateString == null) return null;

            DateTime date;
            DateTime.TryParse(dateString, out date);

            return DateTime.Parse(date.ToShortDateString());
        }
    }
}
