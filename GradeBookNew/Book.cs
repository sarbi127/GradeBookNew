using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GradeBook
{

    public delegate void GradeAddedDelegate(object sender, EventArgs args); 
    
    //inher, base class
    public class NameObject 
    {
        public NameObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    // interface
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NameObject, IBook
    {

        public Book(string name):base(name)
        {

        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);

                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            //writer.Dispose();
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name): base(name)
        {
            grades = new List<double>();
            Name = name;
        }

         public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {

                grades.Add(grade);

                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }

            }
            else
            {
                throw new ArgumentException($"Invalid value");
            }
            

        }

        public override event GradeAddedDelegate GradeAdded;
        public override Statistics GetStatistics()
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

            //Swich 1
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
       //public string Name;
    }
}
