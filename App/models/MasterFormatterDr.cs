using App.models;

namespace App
{
    public class MasterFormatterDr
    {
        public IFormatter Formatter { get; set; }
        public MasterFormatterDr()
        {
        }

        public string format(Calendar calendar)
        {
            return Formatter.format(calendar);
        }
    }
}