using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class Performer
    {
        public Performer()
        {
            PerformerSongs = new HashSet<SongPerformer>();
        }
        //•	Id – Integer, Primary Key
        public int Id { get; set; }
        //•	FirstName – text with max length 20 (required) 
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        //•	LastName – text with max length 20 (required) 
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        //•	Age – Integer(required)
        public int Age { get; set; }
        //•	NetWorth – decimal (required)
        public decimal NetWorth { get; set; }
        //•	PerformerSongs – collection of type SongPerformer
        public ICollection<SongPerformer> PerformerSongs { get; set; }
    }
}
