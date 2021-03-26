using P01_StudentSystem.Data;
using System;
//Should insall for every project:
//Microsoft.EntityFrameworkCore.SqlServer 3.1.3
//Microsoft.EntityFrameworkCore.Design 3.1.3
//Part of 4. Entity-Relations

namespace P01_StudentSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new StudentSystemContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
