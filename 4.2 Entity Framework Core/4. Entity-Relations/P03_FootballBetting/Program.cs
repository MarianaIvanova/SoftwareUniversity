using P03_FootballBetting.Data;
using System;
//Part of 4. Entity-Relations

namespace P03_FootballBetting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new FootballBettingContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
