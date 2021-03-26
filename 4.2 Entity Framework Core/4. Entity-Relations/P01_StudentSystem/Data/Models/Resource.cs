using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        //ResourceId
        public int ResourceId { get; set; }
        //Name(up to 50 characters, unicode)
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        //Url(not unicode)
        [Required]
        [Column(TypeName = "varchar(2048)")]
        public string Url { get; set; }
        //ResourceType(enum – can be Video, Presentation, Document or Other)
        public ResourceType ResourceType { get; set; }// + Ctrl+. choose create class in new file. Then in the new class create enum
        //CourseId
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
