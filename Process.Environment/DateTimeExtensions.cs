using System;

namespace Process.Environment
{
    /// <summary>
    ///
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Adds the workdays.
        /// </summary>
        /// <param name="originalDate">The original date.</param>
        /// <param name="workDays">The work days.</param>
        /// <returns></returns>
        public static DateTime AddWorkdays(this DateTime originalDate, int workDays)
        {
            DateTime tmpDate = originalDate;
            while (workDays > 0)
            {
                tmpDate = tmpDate.AddDays(1);
                if (tmpDate.DayOfWeek < DayOfWeek.Saturday &&
                    tmpDate.DayOfWeek > DayOfWeek.Sunday &&
                    !tmpDate.IsHoliday())
                    workDays--;
            }
            return tmpDate;
        }

        /// <summary>
        /// Determines whether this instance is holiday.
        /// </summary>
        /// <param name="originalDate">The original date.</param>
        /// <returns>
        ///   <c>true</c> if the specified original date is holiday; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsHoliday(this DateTime originalDate)
        {
            if (originalDate.Month == 1 && originalDate.Day >= 1 && originalDate.Day <= 7)
                return true;
            if (originalDate.Month == 5 && originalDate.Day >= 1 && originalDate.Day <= 3)
                return true;
            if (originalDate.Month == 3 && originalDate.Day == 8)
                return true;

            return false;
        }
    }
}
