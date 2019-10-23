using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

         public void AddGrade(double grade)
        {
            grades.Add(grade);

        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MaxValue;
            result.Low = double.MinValue;

            foreach (var grade in grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }

            result.Average /= grades.Count;

            //Swich
            switch(result.Average)
            {

                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;

                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'F';
                    break;


            }
            return result;

        }

        private List<double> grades;
        public string Name;
    }
}
