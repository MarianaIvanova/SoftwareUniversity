using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class SongPerformer
    {
        //•	SongId – Integer, Primary Key
        public int SongId { get; set; }
        //•	Song – the performer’s Song(required)
        public Song Song { get; set; }
        //•	PerformerId – Integer, Primary Key
        public int PerformerId { get; set; }
        //•	Performer – the song’s Performer(required)
        public Performer Performer { get; set; }
    }
}
