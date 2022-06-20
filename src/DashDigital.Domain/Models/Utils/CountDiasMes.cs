using System;
using System.Collections.Generic;
using System.Text;

namespace DashDigital.Domain.Models.Utils
{
    public static partial class CountDiasMes
    {

        public static int GetDifDias() 
        {
            var DataInicial = DateTime.Now;
            //var firstDayOfMonth = new DateTime(initialDate.Year, initialDate.Month, 1).ToString("yyyy'-'MM'-'dd");
            var finalDate = DataInicial.AddDays(-(DataInicial.Day - 1)).AddMonths(1).AddDays(-1).ToString("yyyy'-'MM'-'dd");

            var days = 0;
            var daysCount = 0;
            days = DataInicial.Subtract(Convert.ToDateTime(finalDate).Date).Days;

            if (days < 0)
                days = days * -1;

            for (int i = 0; i <= days; i++) {
                DataInicial = DataInicial.AddDays(1);
                if (DataInicial.DayOfWeek != DayOfWeek.Sunday)
                    //&& //initialDate.DayOfWeek != DayOfWeek.Saturday)
                    daysCount++;
            }
            return daysCount;
        }

        public static int GetDifDiasSab()
        {
            var DataInicial = DateTime.Now;
           // var firstDayOfMonth = new DateTime(initialDate.Year, initialDate.Month, 1).ToString("yyyy'-'MM'-'dd");
            var finalDate = DataInicial.AddDays(-(DataInicial.Day - 1)).AddMonths(1).AddDays(-1).ToString("yyyy'-'MM'-'dd");

            var days = 0;
            var daysSabCount = 0;
            days = DataInicial.Subtract(Convert.ToDateTime(finalDate).Date).Days;

            if (days < 0)
                days = days * -1;

            for (int i = 1; i <= days; i++)
            {
                DataInicial = DataInicial.AddDays(1);
                if (DataInicial.DayOfWeek == DayOfWeek.Sunday) //&&
                    //initialDate.DayOfWeek != DayOfWeek.Saturday)
                    daysSabCount++;
            }
            return daysSabCount;
        }

        public static int GetDifDiasTrabalhados()
        {
            var Hoje = DateTime.Now;
            var PrimeiroDiaMes = new DateTime(Hoje.Year, Hoje.Month, 1);
            var DiaDeOntem = DateTime.Now.AddDays(-1).AddTicks(-1).AddTicks(-1);

            var days = 0;
            var daysCountWorked = 0;
            days = PrimeiroDiaMes.Date.Subtract(Hoje).Days;

            if (days < 0)
                days = days * -1;

            for (int i = 1; i <= days; i++)
            {
                PrimeiroDiaMes = PrimeiroDiaMes.AddDays(1);
                if (PrimeiroDiaMes.DayOfWeek != DayOfWeek.Sunday)
                    //&& //initialDate.DayOfWeek != DayOfWeek.Saturday)
                    daysCountWorked++;
            }
            return daysCountWorked;

        }




    }
}



