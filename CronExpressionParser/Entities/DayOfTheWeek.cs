using System.Linq;

namespace CronExpressionParser.Entities
{
    public class DayOfTheWeek : CronExpression
    {
        public DayOfTheWeek(string cronDayOfTheWeek) : base(cronDayOfTheWeek)
        {
            Values = Enumerable.Range(0, 7).ToList();
        }
    }
}