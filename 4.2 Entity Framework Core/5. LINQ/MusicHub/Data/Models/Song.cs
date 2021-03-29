using MusicHub.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class Song
    {
        public Song()
        {
            SongPerformers = new HashSet<SongPerformer>();
        }
        //•	Id – Integer, Primary Key
        public int Id { get; set; }
        //•	Name – Text with max length 20 (required)
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        //•	Duration – TimeSpan(required)
        [Required]
        public TimeSpan Duration { get; set; }
        //•	CreatedOn – Date(required)
        [Required]
        public DateTime CreatedOn { get; set; }
        //•	Genre ¬– Genre enumeration with possible values: "Blues, Rap, PopMusic, Rock, Jazz" (required)
        [Required]
        public Genre Genre { get; set; }
        //•	AlbumId – Integer, Foreign key
        public int? AlbumId { get; set; }
        //•	Album – The song’s album
        public Album Album { get; set; }
        //•	WriterId – Integer, Foreign key(required)
        public int WriterId { get; set; }
        //•	Writer – The song’s writer
        public Writer Writer { get; set; }
        //•	Price – Decimal(required)
        [Required]
        public decimal Price { get; set; }
        //•	SongPerformers – Collection of type SongPerformer
        public ICollection<SongPerformer> SongPerformers { get; set; }
    }
}
