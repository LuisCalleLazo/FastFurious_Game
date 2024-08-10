using System;
using System.Collections.Generic;

namespace FastFurios_Game.Utils
{
    public static class GetDates
    {
        public static List<string> GetListYearByDate()
        {
            List<string> years = new List<string>();
            int currentYear = DateTime.Now.Year;
            
            for (int year = currentYear; year >= currentYear - 100; year--)
            {
                years.Add(year.ToString());
            }

            return years; 
        }
        
        public static List<string> GetListMonthByDate()
        {
            List<string> months = new List<string>();
            
            for (int month = 1; month <= 12; month++)
            {
                months.Add(month.ToString("D2")); // Agrega los meses como "01", "02", ..., "12"
            }
            return months;
        }

        
        public static List<string> GetListDayByDate()
        {
            List<string> days = new List<string>();

            for (int day = 1; day <= 31; day++)
            {
                days.Add(day.ToString("D2")); // Agrega los días como "01", "02", ..., "31"
            }
            return days;
        }
    }
}