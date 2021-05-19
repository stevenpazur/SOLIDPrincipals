using App.models;

namespace App
{
    public class MasterFormatterDr
    {
        public IFormatter _Formatter;
        public MasterFormatterDr()
        {
        }

        public string format(Calendar calendar)
        {
            return _Formatter.format(calendar);
        }
    }
}