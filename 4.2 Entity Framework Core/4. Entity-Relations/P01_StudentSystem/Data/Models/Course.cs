using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            this.HomeworkSubmissions = new HashSet<Homework>();
            this.Resources = new HashSet<Resource>();
            this.StudentsEnrolled = new HashSet<StudentCourse>();
        }
        //CourseId
        public int CourseId { get; set; }
        //Name(up to 80 characters, unicode)
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        //Description(unicode, not required)
        public string Description { get; set; }
        //StartDate
        public DateTime StartDate { get; set; }
        //EndDate
        public DateTime EndDate { get; set; }
        //Price
        //[Required]?????? - мина така!!!
        public decimal Price { get; set; }
        ////Example for self-reference:
        //public int? CourseParentId { get; set; }
        //public Course CourseParent { get; set; }
        //public ICollection<Course> InverseParents { get; set; }

        public ICollection<Homework> HomeworkSubmissions { get; set; }
        public ICollection<Resource> Resources { get; set; }
        public ICollection<StudentCourse> StudentsEnrolled { get; set; }
    }
}
