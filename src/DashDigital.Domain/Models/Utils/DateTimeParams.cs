using System;
using System.Collections.Generic;
using System.Text;

namespace DashDigital.Domain.Models.Utils
{
    public static partial class DateTimeParams
    {



        public static DateTime DataHoje(this DateTime dt) 
        {
            var DataHoje = DateTime.Now;
            return DataHoje;
        }

        public static DateTime FirstDayPrevioMonth(this DateTime dt) 
        {
            var DataHoje = DateTime.Now;
            var firstDayPrevioMonth = new DateTime(DataHoje.Year, DataHoje.Month, 1).AddMonths(-1).ToString("yyyy'-'MM'-'dd");
            return Convert.ToDateTime(firstDayPrevioMonth).Date;

        }

        public static DateTime LastDayPrevioMonth(this DateTime dt)
        {
            var lastDayPrevioMonth = DateTime.Now.AddDays(-1).ToString("yyyy'-'MM'-'dd"); 
            return Convert.ToDateTime(lastDayPrevioMonth).Date;
        }

        public static DateTime FirstDayOfMonth(this DateTime dt) =>
            new DateTime(dt.Year, dt.Month, 1);


        public static DateTime LastDayOfMonth(this DateTime dt) =>
            dt.FirstDayOfMonth().AddMonths(1).AddDays(-1);

    }
}

