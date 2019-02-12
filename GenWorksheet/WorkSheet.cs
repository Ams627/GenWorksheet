using System;
using System.Linq;
using System.Collections.Generic;

namespace GenWorksheet
{
    internal class WorkSheet
    {
        readonly Random rnd = new Random();
        readonly List<(int, int)> questionList = new List<(int, int)>();

        IEnumerable<(int minuend, int subtrahend)> QuestionGenerator()
        {
            for (; ; )
            {
                var num1 = rnd.Next(10, 99);
                var num2 = rnd.Next(10, 99);
                if (num2 > num1)
                {
                    continue;
                }
                if (rnd.Next(0, 10) > 2)
                {
                    if (num1 % 10 > num2 % 10)
                    {
                        continue;
                    }
                }
                yield return (num1, num2);
            }
        }

        public WorkSheet()
        {
            Console.WriteLine("<!doctype html>");
            Console.WriteLine("<html lang=\"en\">");
            Console.WriteLine("<head>");
            Console.WriteLine("<title>Nothing</title>");
            Console.WriteLine("<style type='text/css'>");
            Console.WriteLine("td {padding:1em;font-family:monospace;text-align: right}");
            Console.WriteLine(".sub {border-bottom:solid black 5px;}");
            Console.WriteLine(".questions {font-size:72pt;}");
            Console.WriteLine(".answers {page-break-before:always;font-size:36pt;}");
            Console.WriteLine("</style>");
            Console.WriteLine("<script>");
            Console.WriteLine("</script>");
            Console.WriteLine("</head>");
            Console.WriteLine("<body>");

            var questions = QuestionGenerator().Take(20).ToList();

            Console.WriteLine("<table class=\"questions\">");
            var count = 0;

            foreach (var sum in questions)
            {
                if (count % 4 == 0)
                {
                    Console.WriteLine("<tr>");
                }
                Console.WriteLine($"<td>&nbsp;{sum.minuend}<br>-<span class=\"sub\">{sum.subtrahend}</span></td>");
                if (count % 4 == 3)
                {
                    Console.WriteLine("</tr>");
                }
                count++;
            }
            Console.WriteLine("</table>");

            Console.WriteLine("<table class=\"answers\">");
            count = 0;

            foreach (var sum in questions)
            {
                if (count % 4 == 0)
                {
                    Console.WriteLine("<tr>");
                }
                Console.WriteLine($"<td>&nbsp;{sum.minuend}<br>-<span class=\"sub\">{sum.subtrahend}</span><br>{sum.minuend - sum.subtrahend}</td>");
                if (count % 4 == 3)
                {
                    Console.WriteLine("</tr>");
                }
                count++;
            }
            Console.WriteLine("</table>");
            Console.WriteLine("</body>");
            Console.WriteLine("</html>");
        }
    }
}