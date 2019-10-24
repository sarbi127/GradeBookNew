using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // 
            var book = new InMemoryBook("Sara");
            book.GradeAdded += OnGradeAdded;
            //book.GradeAdded += OnGradeAdded;
            //book.GradeAdded -= OnGradeAdded;
            //book.GradeAdded += OnGradeAdded;
            //book.AddGrade(89.1);
            //book.AddGrade(1.0);
            //book.AddGrade(3.0);
            //book.GetStatistics();

            EnterGrades(book);

            var stats = book.GetStatistics();


            Console.WriteLine($"The lowest grade is { stats.Low}");
            Console.WriteLine($"The highest grade is { stats.High}");
            Console.WriteLine($"The average grade id { stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");


        }

        private static void EnterGrades(Book book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q'");
                var input = Console.ReadLine();

                if (input == "q")
                {

                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }



            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
       
    }
}
