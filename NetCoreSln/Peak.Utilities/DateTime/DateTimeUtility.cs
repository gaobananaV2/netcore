using System;
using System.Collections.Generic;

namespace Peak.Utilities
{
    public static class DateTimeUtility
    { 

        public static string FormatDate(DateTime? date)
        {
            if (date == null)
            {
                return string.Empty;
            }
            else
            {
                return string.Format("{0:yyyy-MM-dd}", date);
            }
        }


        public static string FormatDate(string dateString)
        {
            var dt = dateString.ToDateTime();
            if (dt == null)
            {
                return string.Empty;
            }
            else
            {
                return string.Format("{0:yyyy-MM-dd}", dt);
            }
        }

        public static string FormatDate(object date)
        {
            var dt = date.ToDateTime();
            if (dt == null)
            {
                return string.Empty;
            }
            else
            {
                return string.Format("{0:yyyy-MM-dd}", dt);
            }
        }

        public static string FormatDateTime(object date)
        {
            if (date == null)
            {
                return string.Empty;
            }
            else
            {
                return string.Format("{0:yyyy-MM-dd HH:mm}", date);
            }
        }

        public static DateTime? ConvertObjectToNullableDate(object obj)
        {
            if (obj == null) return null;
            DateTime tmpDateTime;
            if (DateTime.TryParse(obj.ToString(), out tmpDateTime) == true)
                return tmpDateTime;
            else
                return null;
        
        }


        /// <summary>
        /// 指定的日期格式格式化日期
        /// </summary>
        /// <param name="dateValue">日期</param>
        /// <param name="dataFormat">日期格式</param>
        /// <returns></returns>
        public static string FormatDateTime(DateTime dateValue, string dataFormat)
        {
            string result = null;
            try
            {
                result = dateValue.ToString(dataFormat);
            }
            catch
            {
            }
            return result;
        }


        /// <summary>
        /// 获取两个时间差：返回 年
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static double GetYearsOfTwoDate(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null || endDate == null) return 0;
            int months = DateTimeUtility.GetMonthsOfTwoDate(startDate, endDate);
            double totalyears = months / 12d;
            return double.Parse(string.Format("{0:N2}", totalyears));
        }

        /// <summary>
        /// 获取两个时间差：返回 月
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int GetMonthsOfTwoDate(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null || endDate == null) return 0;
             int months = ((endDate.Value.Year - startDate.Value.Year) * 12) + (endDate.Value.Month - startDate.Value.Month);
            //如果天数还没到，月数要减1
            if (endDate.Value.Day < startDate.Value.Day)
            {
                months--;
            }
            return months;
        }

        /// <summary>
        /// 获取两个时间差：返回 天
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string GetDaysOfTwoDate(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null || endDate == null) return string.Empty;
            TimeSpan TimSpan = endDate.Value.Subtract(startDate.Value);
            return TimSpan.Days.ToString();
        }

        /// <summary>
        /// 获取季度的开始日期        /// </summary>
        /// <param name="year"></param>
        /// <param name="quarter"></param>
        /// <returns></returns>
        public static DateTime? GetStartDateOfQuarter(int year, int quarter)
        {
            string strDt = year.ToString() + "-" + ((quarter-1)*3+1).ToString() + "-1";
            return strDt.ToDateTime();
        }

        /// <summary>
        /// 获取季度的结束日期        /// </summary>
        /// <param name="year"></param>
        /// <param name="quarter"></param>
        /// <returns></returns>
        public static DateTime? GetEndDateOfQuarter(int year, int quarter)
        {
            var startDt = GetStartDateOfQuarter(year, quarter);
            if (startDt == null) return null;
            return startDt.Value.AddMonths(3).AddDays(-1);
        }

        /// <summary>
        /// 获取日期对应的季度        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int GetQuarter(this DateTime input)
        {
            if ((input.Month % 3) > 0)
                return (input.Month / 3 + 1);
            else
                return (input.Month / 3);
        }

        /// <summary>
        /// 获取月份的开始日期
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTime? GetStartDateOfMonth(int year, int month)
        {
            string strDt = year.ToString() + "-" + month.ToString() + "-1";
            return strDt.ToDateTime();
        }

        /// <summary>
        /// 获取月份的结束日期
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTime? GetEndDateOfMonth(int year, int month)
        {
            var startDt = GetStartDateOfMonth(year, month);
            if (startDt == null) return null;
            return startDt.Value.AddMonths(1).AddDays(-1);
        }
      
        #region 周相关计算
        /// <summary>
        /// 获取当前日期第一个星期几是哪天
        ///DateTime dt=getWeekUpOfDate(DateTime.Now,DayOfWeek.Monday,-1);
        /// 这是获取当前日期的上周一的日期
        /// 
        /// DateTime dt=getWeekUpOfDate(DateTime.Now,DayOfWeek.Monday,-2);
        ///这是获取当前日期的上上周一的日期
        ///
        ///DateTime dt=getWeekUpOfDate(DateTime.Now,DayOfWeek.Monday,1);
        ///这是获取当前日期的下周一的日期
        ///
        ///DateTime dt=getWeekUpOfDate(DateTime.Now,DayOfWeek.Monday,0);
        ///这是获取本周周一的日期
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="weekday"></param>
        /// <param name="Number"></param>
        /// <returns></returns>
        public static DateTime GetWeekUpOfDate(DateTime dt, DayOfWeek weekday, int Number)
        {
            int wd1 = (int)weekday;
            int wd2 = (int)dt.DayOfWeek;
            return wd2 == wd1 ? dt.AddDays(7 * Number) : dt.AddDays(7 * Number - wd2 + wd1);
        }
        #endregion

        /// <summary>
        /// 获取日期是当月的第几周
        /// </summary>
        /// <param name="day"></param>
        /// <param name="WeekStart">1表示 周一至周日 为一周 2表示 周日至周六 为一周</param>
        /// <returns></returns>
        public static int WeekOfMonth(DateTime day, int WeekStart)
        {
            //WeekStart
            //1表示 周一至周日 为一周
            //2表示 周日至周六 为一周
            DateTime FirstofMonth;
            FirstofMonth = Convert.ToDateTime(day.Date.Year + "-" + day.Date.Month + "-" + 1);

            int i = (int)FirstofMonth.Date.DayOfWeek;
            if (i == 0)
            {
                i = 7;
            }

            if (WeekStart == 1)
            {
                return (day.Date.Day + i - 2) / 7 + 1;
            }
            if (WeekStart == 2)
            {
                return (day.Date.Day + i - 1) / 7;

            }
            return 0;
            //错误返回值0
        }

        public static List<int> GetYearArray(int start)
        {
            List<int> lst = new List<int>();
            for (var i = start; i <= DateTime.Today.Year; i++)
            {
                lst.Add(i);
            }
            return lst;
        }

        public static DateTime? ParseYearMonthToDateTimeValue(string ymString)
        {
            if (String.IsNullOrEmpty(ymString)) return null;
            ymString = ymString.Replace("年", "-").Replace("月", "-1");
            string dateString = ymString;

            DateTime dtValue;
            if (!DateTime.TryParse(dateString, out dtValue)) return null;
            return dtValue;
        }
        public static string ParseDateToYearMonth(object dt)
        {
            var dtObj = dt.ToDateTime();
            if (dtObj == null) return string.Empty;
            return string.Format("{0}年{1}月", dtObj.Value.Year, dtObj.Value.Month);
        }

    }
}
