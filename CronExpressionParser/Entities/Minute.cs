using System.Linq;

namespace CronExpressionParser.Entities
{
    public class Minute : CronExpression
    {
        public Minute(string cronMinute) : base(cronMinute)
        {
            Values = Enumerable.Range(0, 60).ToList();
        }
    }
}