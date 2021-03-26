using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        public Team()
        {
            this.HomeGames = new HashSet<Game>();
            this.AwayGames = new HashSet<Game>();
            this.Players = new HashSet<Player>();
        }
        //TeamId, Name, LogoUrl, Initials(JUV, LIV, ARS…), Budget, PrimaryKitColorId, SecondaryKitColorId, TownId
        public int TeamId { get; set; }
        //[Required]
        public string Name { get; set; }
        //[Required]
        //[Column(TypeName = "varchar(255)")]
        public string LogoUrl { get; set; }
        public string Initials { get; set; }
        public decimal Budget { get; set; }
        public int PrimaryKitColorId { get; set; }
        public Color PrimaryKitColor { get; set; }
        public int SecondaryKitColorId { get; set; }
        public Color SecondaryKitColor { get; set; }
        public int TownId { get; set; }
        public Town Town { get; set; }
        //[InverseProperty(nameof(Game.HomeTeam))]//added by me, but use API like teacher
        public ICollection<Game> HomeGames { get; set; }
        //[InverseProperty(nameof(Game.AwayTeam))]//added by me, but use API like teacher
        public ICollection<Game> AwayGames { get; set; }
        public ICollection<Player> Players { get; set; } 
    }
}
