using System;
using System.Text;
using CronExpressionParser.Entities;

namespace CronExpressionParser
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                throw new Exception("Cron string must be in 1 argument");
            }

            var cronParts = args[0].Split(' ');

            
            if (cronParts.Length != 6)
            {
                throw new Exception("Cron string must be in 6 parts.");
            }

            try
            {

                var minute = new Minute(cronParts[0]);
                var hour = new Hour(cronParts[1]);
                var dayOfTheMonth = new DayOfTheMonth(cronParts[2]);
                var month = new Month(cronParts[3]);
                var dayOfTheWeek = new DayOfTheWeek(cronParts[4]);
                var command = cronParts[5];

                var result = new StringBuilder();
                result.AppendLine($"minute         {minute.GetValue()}");
                result.AppendLine($"hour           {hour.GetValue()}");
                result.AppendLine($"dayOfTheMonth  {dayOfTheMonth.GetValue()}");
                result.AppendLine($"month          {month.GetValue()}");
                result.AppendLine($"dayOfTheWeek   {dayOfTheWeek.GetValue()}");
                result.AppendLine($"command        {command}");
                
                Console.WriteLine(result.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}