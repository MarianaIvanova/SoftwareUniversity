using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            this.HomeworkSubmissions = new HashSet<Homework>();
            this.CourseEnrollments = new HashSet<StudentCourse>();
        }
        //StudentId
        public int StudentId { get; set; }
        //Name(up to 100 characters, unicode)//String is mapping as unicode i.e.NVARCHAR and is not required
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        //PhoneNumber(exactly 10 characters, not unicode, not required) !!!!
        [Column(TypeName = "char(10)")]
        public string PhoneNumber { get; set; }
        //RegisteredOn
        public DateTime RegisteredOn { get; set; }//DateTime is always required
        //Birthday(not required)
        public DateTime? Birthday { get; set; }
        public ICollection<Homework> HomeworkSubmissions { get; set; }
        public ICollection<StudentCourse> CourseEnrollments { get; set; }
    }
}
