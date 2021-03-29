using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public Album()
        {
            Songs = new HashSet<Song>();
        }
        //•	Id – Integer, Primary Key
        public int Id { get; set; }
        //•	Name – Text with max length 40 (required)
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        //•	ReleaseDate – Date(required)
        public DateTime ReleaseDate { get; set; }
        //•	Price – calculated property(the sum of all song prices in the album)
        public decimal Price => this.Songs.Sum(x => x.Price);
        //•	ProducerId – integer, Foreign key
        public int? ProducerId { get; set; }
        //•	Producer – the album’s producer
        public Producer Producer { get; set; }
        //•	Songs – collection of all Songs in the Album
        public ICollection<Song> Songs { get; set; }
    }
}
