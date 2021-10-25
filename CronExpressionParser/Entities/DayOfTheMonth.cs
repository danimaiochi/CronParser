using System.Linq;

namespace CronExpressionParser.Entities
{
    public class DayOfTheMonth : CronExpression
    {
        public DayOfTheMonth(string cronDayOfTheMonth) : base(cronDayOfTheMonth)
        {
            Values = Enumerable.Range(1, 31).ToList();

            /*
            if (month == 2)
            {
                Values.Remove(30);
                Values.Remove(29);
                
            }

            if (month is 1 or 3 or 5 or 7 or 8 or 10 or 12)
            {
                Values.Add(31);
            }
            */
        }
    }
}