using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class Producer
    {
        public Producer()
        {
            Albums = new HashSet<Album>();
        }
        //•	Id – Integer, Primary Key
        public int Id { get; set; }
        //•	Name – text with max length 30 (required)
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        //•	Pseudonym – text
        public string Pseudonym { get; set; }
        //•	PhoneNumber – text
        public string PhoneNumber { get; set; }
        //•	Albums – collection of type Album
        public ICollection<Album> Albums { get; set; }
    }
}
