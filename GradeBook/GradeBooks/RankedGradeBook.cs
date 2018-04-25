using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook (string name): base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                 return;
            }
                base.CalculateStatistics();
        
        }

        public override void CalculateStudentStatistics(string name)
        {
            base.CalculateStudentStatistics(name);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override double GetGPA(char letterGrade, StudentType studentType)
        {
            return base.GetGPA(letterGrade, studentType);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count > 5)
                throw new InvalidOperationException("Required 5 more students for grading");

            var thresold = (int)Math.Ceiling(Students.Count * 0.2);
            var grade = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grade[thresold - 1] <= averageGrade)
                return 'A';
            else if (grade[(thresold * 2) - 1] <= averageGrade)
                return 'B';
            else if (grade[(thresold * 3) - 1] <= averageGrade)
                return 'C';
            else if (grade[(thresold * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }

 

   
    }
}
