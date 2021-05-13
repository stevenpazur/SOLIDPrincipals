using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace App
{
    public class MonthlyFormatter {
        public string format(Calendar calendar) {
            if (calendar.getFirstDateTime() == null) return "";

            var date1 = calendar.getFirstDateTime().Value;
            var startMonth = new DateTime(date1.Year, date1.Month, 1);

            var date2 = calendar.getLastDateTime().Value;
            var endMonth = new DateTime(date2.Year, date2.Month, DateTime.DaysInMonth(date2.Year, date2.Month));

            List<DateTime> dates = new List<DateTime>();
            var current = startMonth;
            while(current <= endMonth)
            {
                dates.Add(current);
                current = current.AddDays(1);
            }

            var monthGroups = from d in dates group d by d.Month;

            StringBuilder builder = new StringBuilder();

            foreach (var monthGroup in monthGroups)
            {
                var monthString = new DateTime(2021, monthGroup.Key, 1).ToString("MMMM");
                builder.Append(monthString + "\n");

                foreach(var date in monthGroup)
                {
                    builder.Append(date.Day);

                    if(calendar.descriptionsFor(date).Count() > 0)
                    {
                        builder.Append("*");
                    }

                    builder.Append(" ");
                }

                builder.Append("\n\n");
            }

            return builder.ToString();
        }
    }
}
