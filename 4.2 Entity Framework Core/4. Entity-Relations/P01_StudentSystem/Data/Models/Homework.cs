using System;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        //HomeworkId
        public int HomeworkId { get; set; }
        //Content(string, linking to a file, not unicode)
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Content { get; set; }
        //ContentType(enum – can be Application, Pdf or Zip)
        public ContentType ContentType { get; set; }
        //SubmissionTime
        public DateTime SubmissionTime { get; set; }
        //StudentId
        public int StudentId { get; set; }
        public Student Student { get; set; }
        //CourseId
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
