using System;
using System.Collections.Generic;
using System.Linq;

namespace App.models
{
    public class Calendar
    {
        private List<IGetStartsAt> schedulables = new();

        public void addSchedulable(IGetStartsAt schedulable)
        {
            schedulables.Add(schedulable);
            schedulables = schedulables.OrderBy(s => getLocalDateTime(s)).ToList();
        }

        public List<IGetStartsAt> items()
        {
            return schedulables;
        }
        public List<DateTime> dates()
        {
            return schedulables
              .Select(s => getLocalDateTime(s)).ToList();
        }

        public List<string> descriptionsFor(DateTime date)
        {
            return schedulables
              .Where(s => getLocalDateTime(s).Date == date)
              .Select(s => s.ToString()).ToList();
        }
        public DateTime getFirstDateTime()
        {
            IGetStartsAt item = schedulables.First();
            return getLocalDateTime(item);
        }
        public DateTime getLastDateTime()
        {
            var item = schedulables.Last();
            return getLocalDateTime(item);
        }

        public string format()
        {
            var formatter = new MonthlyFormatter();
            return formatter.format(this);
        }

        private DateTime getLocalDateTime(IGetStartsAt item)
        {
            return item.getStartsAt();
        }
        
    }
}