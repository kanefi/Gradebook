using System;
using System.Collections.Generic;

namespace Gradebook
{
    public class Book
    {
        public Book(string name)
         {
             grades = new List<double>();
              Name = name; 
         }

        public void AddLetterGrade(char letter)
        {
            switch(letter)
            {
                case 'A':                   // single quotes, if used double quotes compiler would treat as a string
                AddGrade(90);
                break;

                case 'B':
                AddGrade(80);
                break;

                case 'C':
                AddGrade(70);
                break;

                default:
                AddGrade(0);
                break;
                
            }
        }

        public void AddGrade(double grade)
        {
            // if(grade <= 100 || grade > 0)       // Will read left side first and this is succesful, don't need to evaluate the right hand side. || aka SHORT CIRCUITING.
           if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);        
            }
            else
            {
                // System.Console.WriteLine("Invalid value");
            throw new ArgumentException($"Invalid {nameof(grade)}");
            
            }

        }
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;   
            result.Low = double.MaxValue;

            for(var index = 0; index < grades.Count; index +=1)
            
            {
                result.Low = Math.Min(grades[index], result.Low);           //need to keep track of which index we are at, unlike foreach looping which does this for us. Declare the index as 0 or i.
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index]; 
               
            }                                                               // not <= grades.Count because of zero indexing.
            
            result.Average /= grades.Count;

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
                result.Letter = 'F' ;
                break;


            }

            return result;
           } 
        private List<double> grades;
        public string Name
        {
            get;
            set;
           
        }
    }        
      
}