using System.Linq;

namespace CronExpressionParser.Entities
{
    public class Hour : CronExpression
    {
        public Hour(string cronHour) : base(cronHour)
        {
            Values = Enumerable.Range(0, 24).ToList();
        }
    }
}