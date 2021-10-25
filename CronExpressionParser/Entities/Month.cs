using System.Linq;

namespace CronExpressionParser.Entities
{
    public class Month : CronExpression
    {
        public Month(string cronMonth) : base(cronMonth)
        {
            Values = Enumerable.Range(1, 12).ToList();
        }
    }
}