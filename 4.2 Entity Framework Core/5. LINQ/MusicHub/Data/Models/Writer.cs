using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class Writer
    {
        public Writer()
        {
            Songs = new HashSet<Song>();
        }
        //•	Id – Integer, Primary Key
        public int Id { get; set; }
        //•	Name – text with max length 20 (required)
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        //•	Pseudonym – text
        public string Pseudonym { get; set; }
        //•	Songs – collection of type Song
        public ICollection<Song> Songs { get; set; }
    }
}
