using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // 
            var book = new Book("Sara");
            book.AddGrade(89.1);
            book.AddGrade(1.0);
            book.AddGrade(3.0);
            book.GetStatistics();


            var stats = book.GetStatistics();


            Console.WriteLine($"The lowest grade is { stats.Low}");
            Console.WriteLine($"The highest grade is { stats.High}");
            Console.WriteLine($"The average grade id { stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");


        }

       
    }
}
