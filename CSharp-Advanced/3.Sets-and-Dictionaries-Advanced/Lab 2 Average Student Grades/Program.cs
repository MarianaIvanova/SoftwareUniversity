using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_2_Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentRecord = new Dictionary<string, List<decimal>>();

            for (int i = 1; i <= numberOfStudents; i++)
            {
                string[] studentsInfo = Console.ReadLine().Split(" ").ToArray();
                string name = studentsInfo[0];
                decimal grade = decimal.Parse(studentsInfo[1]);

                if(!studentRecord.ContainsKey(name))
                {
                    studentRecord.Add(name, new List<decimal>());
                    studentRecord[name].Add(grade);
                }
                else
                {
                    studentRecord[name].Add(grade);
                }
            }

            //1 Printing foreach
            //foreach (var grade in studentRecord)
            //{
            //    Console.WriteLine($"{grade.Key} -> {string.Join(" ", grade.Value)} (avg: {grade.Value.Average():F2})");
            //}

            //3 Method with StringBuilder:
            foreach (var grade in studentRecord)//The results for grades is like 5.5 not 5.50 int this case
            {
                StringBuilder allGrades = new StringBuilder();
                for (int i = 0; i < grade.Value.Count; i++)
                {
                    allGrades.Append($"{grade.Value[i]:F2} ");
                }
                Console.WriteLine($"{grade.Key} -> {allGrades}(avg: {grade.Value.Average():F2})");
            }

            //3 method with foreach in foreach:
            //foreach (var pair in studentRecord)//The results for grades is like 5.5 not 5.50 int this case
            //{
            //    var name = pair.Key;
            //    Console.Write($"{name} -> ");

            //    var strudentsGrades = pair.Value;
            //    foreach (var grade in strudentsGrades)
            //    {
            //        Console.Write($"{grade:F2} ");
            //    }

            //    var average = pair.Value.Average();
            //    Console.WriteLine($"(avg: {average:F2})");
            //}
        }
    }
}
