using P01_HospitalDatabase.Data;
using System;
//Part of 4. Entity-Relations

namespace P01_HospitalDatabase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new HospitalContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
