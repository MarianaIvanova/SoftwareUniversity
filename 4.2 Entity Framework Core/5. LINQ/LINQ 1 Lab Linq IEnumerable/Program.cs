using System;
using System.Collections.Generic;
using System.Linq;

//Should insall for every project:
//Microsoft.EntityFrameworkCore.SqlServer 3.1.3
//Microsoft.EntityFrameworkCore.Design 3.1.3
//Part of 5. LINQ

namespace LINQ_1_Lab_Linq_IEnumerable
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var collection = new List<Student>()
            {
                new Student { Name = "Niki", Marks = new List<int> { 2,3,2,3,2} },
                new Student { Name = "Stoyan", Marks = new List<int>{ 6,5,6,5,6} },
                new Student { Name = "Nivo", Marks = new List<int>{ 6,6,6,6,6} }
            };
            
            var collection2 = collection.Where(x => x.Name.StartsWith("N"));//using System.Linq;
            foreach (var student in collection2)
            {
                Console.WriteLine(student.Name + " " + string.Join(", ",student.Marks));
            }
            //Niki 2, 3, 2, 3, 2
            //Nivo 6, 6, 6, 6, 6

            Console.WriteLine();
            var collection3 = collection.Where(Predicate);
            foreach (var student in collection3)
            {
                Console.WriteLine(student.Name + " " + string.Join(", ", student.Marks));
            }
            //Stoyan 6, 5, 6, 5, 6
            //Nivo 6, 6, 6, 6, 6

            Console.WriteLine();
            var collection4 = collection
                .Where(x => x.Marks.Average() >= 5)//See Predicate3 - it is the same// Where is makes selection
                //x - here is Student
                .Select(x => new StudentProjection //Select makes projection class StudentProjection
                {
                    Name = x.Name,
                    NameInitial = x.Name.Substring(0,1),
                    AverageMarks = x.Marks.Average(),
                })
                .OrderByDescending(x => x.AverageMarks); //x - here is StudentProjection and all below will be 

            foreach (var student in collection4)
            {
                Console.WriteLine($"{student.Name} {student.AverageMarks}");
            }
            //Nivo 6
            //Stoyan 5.6

            Console.WriteLine();
            var collection5 = collection
                .Where(x => x.Marks.Average() >= 5)//See Predicate3 - it is the same// Where is makes selection
                                                   //x - here is Student
                .Select(x => new  //Select makes projection - in this case it makes anonymus class, no need to create it below as we have done in collection5
                {
                    Name = x.Name,
                    NameInitial = x.Name.Substring(0, 1),
                    AverageMarks = x.Marks.Average(),
                })
                .OrderByDescending(x => x.AverageMarks); //x - here is StudentProjection and all below will be 

            foreach (var student in collection5)
            {
                Console.WriteLine($"{student.Name} {student.AverageMarks}");
            }
            //Nivo 6
            //Stoyan 5.6

            Console.WriteLine();
            var groups = collection
                .Select(x => new 
                {
                    Name = x.Name,
                    NameInitial = x.Name.Substring(0, 1),
                    AverageMarks = x.Marks.Average(),
                })
                .OrderByDescending(x => x.AverageMarks) //x - here is StudentProjection and all below will be 
                .GroupBy(x => x.NameInitial);

            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Key} {group.Count()}");
            }
            //N 2
            //S 1
        }
        //Predicate function writting 1:
        static bool Predicate(Student student)
        {
            if (student.Marks.Average() >= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Predicate function writting 2.1:
        static bool Predicate2(Student student) => student.Marks.Average() >= 5;
        //Predicate function writting 2.2:
        static bool Predicate3(Student x) => x.Marks.Average() >= 5;
    }
    class StudentProjection // No need to create this class we can use in LING - anonymus class - see collection5
    {
        public string Name { get; set; }
        public string NameInitial { get; set; }//We Need only the first letter of the Name of the student 
        public double AverageMarks { get; set; }
    }
    class Student
    {
        public string Name { get; set; }
        public List<int> Marks { get; set; }
    }
}
