using System.Text;
using App.models;

namespace App
{
    public class ScheduleFormatter : IFormatter
    {
        public string format(Calendar calendar)
        {
            var builder = new StringBuilder();

            calendar.dates().ForEach(date =>
            {
                builder.Append(date).Append("\n");

                if (date != null)
                    calendar.descriptionsFor(date.Value).ForEach(description =>
                    {
                        builder.Append(" - ").Append(description).Append("\n");
                    });

                builder.Append("\n");
            });

            return builder.ToString();
        }
    }
}