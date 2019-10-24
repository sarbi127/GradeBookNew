using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {

            get
            {

                return Sum / Count;
            }
        }
        public double High;
        public double Low;
        public char Letter
        {

            get
            {
                //Swich 1
                switch (Average)
                {


                    case var d when d >= 90.0:
                        return 'A';

                    case var d when d >= 80.0:
                        return 'B';
                        

                    case var d when d >= 70.0:
                        return 'C';
                        

                    case var d when d >= 60.0:
                        return 'D';
                        

                    default:
                        return 'F';
                       


                }

            }
        }
        public double Sum;
        public int Count;
        private byte low;

        public void Add(double number)
        {
            Sum += number;
            Count += 1;

            Low = Math.Min(number, low);
            High = Math.Max(number, High);
        }

        public Statistics()
        {
            Count = 0;
            High = double.MinValue;
            Low = double.MaxValue;
            
        }
    }
}
