using System;
using System.Collections.Generic;
using System.Linq;

namespace CronExpressionParser.Entities
{
    public abstract class CronExpression
    {
        protected List<int> Values;

        public string Cron;

        protected CronExpression(string cronExpression)
        {
            Cron = cronExpression;
        }

        public string GetValue()
        {
            if (Cron == "*")
            {
                return GetAllValues();
            }

            if (Cron.Contains(','))
            {
                return GetSpecificValues();
            }

            if (Cron.Contains('-'))
            {
                return GetRangeOfValues();
            }
            
            if (Cron.Contains('/'))
            {
                return GetSkippedValues();
            }

            if (int.TryParse(Cron, out int val))
            {
                return val.ToString();
            }
            
            throw new Exception($"Invalid CRON expression: {Cron}");
        }

        private string GetAllValues()
        {
            return string.Join(' ', Values);
        }

        private string GetSpecificValues()
        {
            try
            {
                var separateValues = Cron.Split(',').ToList();
                var intValues = new List<int>();

                foreach (var separateValue in separateValues)
                {
                    var intValue = int.Parse(separateValue);
                    intValues.Add(intValue);
                }
                    
                return string.Join(' ', intValues.Where(x => Values.Contains(x)).ToList());
            }
            catch (Exception)
            {
                throw new Exception($"Invalid Cron expression: {Cron}");
            }
        }

        private string GetRangeOfValues()
        {
            try
            {
                var expressionParts = Cron.Split('-');

                var start = int.Parse(expressionParts[0]);
                var end = int.Parse(expressionParts[1]);

                if (start > end)
                {
                    throw new Exception("In range expressions, start cannot be greater than the end");
                }

                if (Values.Contains(start) && Values.Contains(end))
                {
                    var indexStart = Values.IndexOf(start);
                    var indexEnd = Values.IndexOf(end);
                    
                    return string.Join(' ', Values.GetRange(indexStart, indexEnd - indexStart +1));
                }
                else
                {
                    throw new Exception("Values provided are outside the range");
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Invalid Cron expression: {Cron}. {e.Message}");
            }
        }

        private string GetSkippedValues()
        {
            try
            {
                var expressionParts = Cron.Split('/');

                var startExpressionPart = expressionParts[0];
                int start = 0;
                var interval = int.Parse(expressionParts[1]);

                if (startExpressionPart == "*")
                {
                    start = 0;
                }
                else
                {
                    start = Values.IndexOf(int.Parse(startExpressionPart));
                }

                var matches = new List<int>();

                for (int i = start; i < Values.Count; i+=interval)
                {
                    matches.Add(Values[i]);
                }

                return string.Join(' ', matches);
            }
            catch (Exception e)
            {
                throw new Exception($"Invalid Cron expression: {Cron}. {e.Message}");
            }
        }
    }
}