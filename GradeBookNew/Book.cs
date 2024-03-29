﻿using System;
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
            var result = new Statistics();

            using (var reader = File.OpenText($"{Name}.txt"))
            {

                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();

                }
            }

            return result;
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


            for(var index = 0; index < grades.Count; index += 1 )
            {
                result.Add(grades[index]);

            }
      
            return result;

        }

        private List<double> grades;
       //public string Name;
    }
}
