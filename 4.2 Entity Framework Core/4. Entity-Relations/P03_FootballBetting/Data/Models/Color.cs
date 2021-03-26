using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class Color
    {
        public Color()
        {
            this.PrimaryKitTeams = new HashSet<Team>();
            this.SecondaryKitTeams = new HashSet<Team>();
        }
        //ColorId, Name
        public int ColorId { get; set; }
        //[Required]
        public string Name { get; set; }
        //[InverseProperty(nameof(Team.PrimaryKitColorId))] //added by me, but use API like teacher
        public ICollection<Team> PrimaryKitTeams { get; set; } 
        //[InverseProperty(nameof(Team.SecondaryKitColor))] //added by me, but use API like teacher
        public ICollection<Team> SecondaryKitTeams { get; set; }
    }
}
