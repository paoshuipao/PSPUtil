
using System;

namespace PSPUtil.Extensions
{
    public static class Extensions_DateTime
    {

        /// <summary>
        /// 如果日期处于两个其他日期之间，则返回true。
        /// </summary>
        /// <param name="date">Date checked.</param>
        /// <param name="from">Start of period.</param>
        /// <param name="to">End of period.</param>
        /// <returns></returns>
        public static bool IsBetween(this DateTime date, DateTime from, DateTime to)
        {
            return ((from <= date) && (to >= date));
        }



        /// <summary>
        /// 将日期返回为午夜   -> new DateTime（年，月，日） -> 后面时间没有则为 12:00:00 AM
        /// </summary>
        /// <param name="date">Date.</param>
        public static DateTime Midnight(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }



        /// <summary>
        /// Returns the first day of the month.
        /// </summary>
        /// <param name="date">Date.</param>
        /// <returns></returns>
        public static DateTime FirstOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        /// <summary>
        /// Returns the last day of the month
        /// </summary>
        /// <param name="date">Date.</param>
        /// <returns></returns>
        public static DateTime EndOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// Returns yesterday's date (keeps the time)
        /// </summary>
        /// <param name="date">Date.</param>
        /// <returns></returns>
        public static DateTime Yesterday(this DateTime date)
        {
            return date.AddDays(-1);
        }

        /// <summary>
        /// Returns yesterday's date at midnight
        /// </summary>
        /// <param name="date">Date.</param>
        /// <returns></returns>
        public static DateTime YesterdayMidnight(this DateTime date)
        {
            return date.Yesterday().Midnight();
        }

        /// <summary>
        /// Returns Tomorrow's date (keeps the time)
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime Tomorrow(this DateTime date)
        {
            return date.AddDays(1);
        }

        /// <summary>
        /// Returns Tomorrow's date at midnight
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime TomorrowMidnight(this DateTime date)
        {
            return date.Tomorrow().Midnight();
        }

        /// <summary>
        /// Returns true if both dates are on the same day.
        /// </summary>
        /// <param name="date">Date.</param>
        /// <param name="compareDate">Date to be compared.</param>
        /// <returns></returns>
        public static bool IsSameDay(this DateTime date, DateTime compareDate)
        {
            return date.Midnight().Equals(compareDate.Midnight());
        }

        /// <summary>
        /// Returns true if the date is greater than <paramref name="compareDate"/>
        /// </summary>
        /// <param name="date">Date.</param>
        /// <param name="compareDate">Date to compare.</param>
        /// <returns></returns>
        public static bool IsLaterDate(this DateTime date, DateTime compareDate)
        {
            return date > compareDate;
        }

        /// <summary>
        /// Returns true if the date is less than <paramref name="compareDate"/>
        /// </summary>
        /// <param name="date">Date.</param>
        /// <param name="compareDate">Date to compare.</param>
        /// <returns></returns>
        public static bool IsOlderDate(this DateTime date, DateTime compareDate)
        {
            return date < compareDate;
        }

        /// <summary>
        /// Checks whether the given day is Today.
        /// </summary>
        /// <param name="date">Date.</param>
        /// <returns>True if the given day is Today, false otherwise.</returns>
        public static bool IsToday(this DateTime date)
        {
            return date.Date == DateTime.Now.Date;
        }

        /// <summary>
        /// Checks whether the given day is Tomorrow.
        /// </summary>
        /// <param name="date">Date.</param>
        /// <returns>True if the given day is Tomorrow, false otherwise.</returns>
        public static bool IsTomorrow(this DateTime date)
        {
            return date.Date == DateTime.Now.Date.AddDays(1);
        }

        /// <summary>
        /// Checks whether the given day is Yesterday.
        /// </summary>
        /// <param name="date">Date.</param>
        /// <returns>True if the given day is yesterday, false otherwise.</returns>
        public static bool IsYesterday(this DateTime date)
        {
            return date.Date == DateTime.Now.Date.AddDays(-1);
        }





    }
}
