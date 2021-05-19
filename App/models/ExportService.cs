using System.Collections.Generic;
using System.Text;

namespace App
{
    public class ExportService
    {
        public string export(List<CalendarItem> objectsToExport)
        {
            var builder = new StringBuilder()
              .Append("BEGIN:VCALENDAR\n")
              .Append("VERSION:2.0\n");

            objectsToExport.ForEach(o => builder.Append("\n" + o.iCalendar()));

            return builder
              .Append("END:VCALENDAR")
              .ToString();
        }
    }
}