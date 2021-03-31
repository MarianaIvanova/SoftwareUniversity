using AdvancedQuerying_1_Lab.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Z.EntityFramework.Plus;

//Should insall for every project:
//Microsoft.EntityFrameworkCore.SqlServer 3.1.3 - for lecture - we use 5.0.3
//Microsoft.EntityFrameworkCore.Design 3.1.3 - for lecture - we use 5.0.3
//Z.EntityFramework.Plus.EFCore for this lecture - I use 5.1.28
//Microsoft.EntityFrameworkCore.Proxies
//Part of 6. Advanced-Querying

namespace AdvancedQuerying_1_Lab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;//using System.Text;
            var db = new MusicXContext();
            //I. Executing Native SQL Queries
            //1. Not Select, no return data - only affected lines from create, update, delete...we use Database.ExecuteSqlRaw(""):
            db.Database.ExecuteSqlRaw("UPDATE Songs SET ModifiedOn = GETDATE()");
            //If we have some Stored Procedure with parameters, which avoid SQL injection - we can use (for SoftUni DB is working, as the procerude is created there)
            //var db = new SoftUniContext();
            //var employeeId = 1;//param
            //var projectId = 1;//param
            //db.Database.ExecuteSqlInterpolated($"EXEC sp_AddEmployeeToProjest {employeeId}, {projectId}");

            //2 Select - returns collection or value
            //2.1 We use DbSet..FromSqlRaw("")
            //-JOIN statements don’t get mapped to the entity class
            //-Required columns must always be selected
            //-Target table must be the same as the DbSet
            var maxId = Console.ReadLine();
            var songs = db.Songs
                .FromSqlRaw("SELECT * FROM Songs WHERE Id <= " + maxId)
                .ToList();
            foreach (var song in songs)
            {
                Console.WriteLine($"{song.Id} => {song.Name}");
            }
            //If we give 4
            //1 => Dream On
            //2 => Heard It All Before
            //3 => It's Been A While
            //4 => Buckeye Bugs

            //SQL injection
            //If we write: 0 UNION SELECT * FROM Songs WHERE Name like '%Ni%'
            //7 => It's Raining Men
            //19 => One Wild Night
            //48 => Berliini
            //65 => Miss California...//All songs with Ni in the name so we should write it like this:

            //2.21 Avoiding SQL injection with PARAMETER
            var maxId2 = Console.ReadLine();
            var songs2 = db.Songs
                .FromSqlRaw("SELECT * FROM Songs WHERE Id <= {0}", maxId2)//This is with PARAMETER to avoid injection.
                .ToList();
            foreach (var song in songs2)
            {
                Console.WriteLine($"{song.Id} => {song.Name}");
            }

            //2.22 Avoiding SQL injection with special INTERPOLATION string
            var maxId3 = Console.ReadLine();
            var songs3 = db.Songs
                .FromSqlInterpolated($"SELECT * FROM Songs WHERE Id <= {maxId3}")//INTERPOLATION
                .ToList();
            foreach (var song in songs3)
            {
                Console.WriteLine($"{song.Id} => {song.Name}");
            }

            //2.2 Or we use Linq:
            var songs4 = db.Songs.Where(x => x.Id <= 10);
            foreach (var song in songs4)
            {
                Console.WriteLine(song.Name);
            }

            //II. Object State Tracking (change tracker in EF):
            //1. NO .ToLIST(), NO Select, THIS is NOT anonymus type object i.e it's a part of the DbSets. In this case EF automatically starts to follow this object! All object's changes are recorded by the EF. EF track changes of the object!
            var songs5 = db.Songs.Where(x => x.Name.Contains("viv"));
            foreach (var song in songs5)
            {
                Console.WriteLine(song.Name);
                song.ModifiedOn = DateTime.UtcNow;
            }
            //Survivor
            //Survivor(European Remix)
            //Vive El Verano
            //Vivir Asi Es Morir De Amor
            //Vivre La Vie...
            //If we take an object from the database from the DbSets we have, EF have to track their changes!
            //The change made above (song.ModifiedOn = DateTime.UtcNow;) is made only locally here in the code, to have it in the DB, we should save the changes:
            db.SaveChanges();

            //2. NO .ToLIST(), YES Select, THIS is A anonymus type or IT's a CLASS we create here object i.e it's NOT a part of the DbSets. For anonymus type objects - it's properties are even read-only. In this case EF doesn't follows this object! EF DOESN't track changes of the object! We can't save any changes for this object - even if we write .SaveChanges()!
            var songs6 = db.Songs.Where(x => x.Name.Contains("viv")).Select(x => new Projection
            {
                Name = x.Name,
                ModifiedOn = x.ModifiedOn,
            });
            foreach (var song in songs6)
            {
                Console.WriteLine(song.Name);
                song.Name = "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
            }

            db.SaveChanges();//Doesn't save the changes in the DB.

            //Attaching and Detaching Objects:
            //2.1 Attaching Objects - EF track changes of the object! SaveChanges() - works for these objects.
            //By default everything from our DbSets, which is not anonymus or Projection class is Attached! 

            //2.2 Detaching Objects - EF DOESN't track changes of the object! SaveChanges() - doesn't works for these objects. We detach objects when we are sure we are not going to change anything in the object or we want to make changes but don't want them to go in the DB. The performeance is better when the object is not attacheched.
            //By default everything which is anonymus or Projection class is Detached, i.e. when we use Select! 
            //2.21 Detaching for the whole collection with .AsNoTracking() 
            var songs7 = db.Songs
                .AsNoTracking() //Detaching Objects with this line - write it after DbSet! 
                .Where(x => x.Id <= 10)
                .ToList();
            foreach (var song in songs7)
            {
                Console.WriteLine(song.Name);
                song.SourceItemId = "!!!!!!!!!!!!!!";
            }

            //2.22 Detaching an element/ object by element/ object in foreach and Attaching again with:
            //db.Entry(song).State = EntityState.Detached;
            //db.Entry(song).State = EntityState.Modified;
            //When an object is tracked and we make changes - EF makes the changes which he tacked - only them.
            //When an object has been untracked with EntityState.Detached;, when we write again EntityState.Modified;, EF will update all fields of the object as it doesn't know what changes we have done.
            var songs8 = db.Songs
                .Where(x => x.Id <= 10)
                .ToList();
            foreach (var song in songs8)
            {
                //EntityState can be Modified, Added, Deleted, Detached, Unchange:
                db.Entry(song).State = EntityState.Detached;//At this moment EF stops tracking it!
                Console.WriteLine(song.Name);
                song.SourceItemId = "!!!!!!!!!!!!!!!!!";//No changes will be done in the DB if we don't have again .Modified;! But if we write again .Modified; below - it will save the changes!!!
                ////We can attach it again with:
                //db.Entry(song).State = EntityState.Modified;
            }

            db.SaveChanges();

            //III. Bulk Operations (Batch Delete and Batch Update) - install: Z.EntityFramework.Plus.EFCore
            //We can't delete tables which don't have a primary key
            //Using Update and Delete in Linq
            //1. Batch Delete
            //var db = new SoftUniContext();
            //db.EmployeesProjects.Where(x => x.ProjectId < 3).Delete();//Thanks too Z.EntityFramework.Plus.EFCore and using Z.EntityFramework.Plus;
            //2 Batch Update
            //UPDATE Songs SET SourceItemId = CAST(Id as nvarchar) WHERE Id <= 10
            //2.1 Batch Update in one
            db.Songs.Where(x => x.Id <= 10)
                .Update(oldSong => new Song { SourceItemId = oldSong.Id.ToString() });//Thanks too Z.EntityFramework.Plus.EFCore and using Z.EntityFramework.Plus; Can't use in Judge!

            //2.2 Batch Update in two parts
            var iq = db.Songs.Where(x => x.Id <= 10);
            iq.Update(oldSong => new Song { SourceItemId = oldSong.Id.ToString() });//Thanks too Z.EntityFramework.Plus.EFCore and using Z.EntityFramework.Plus; Doesn't work in Judge
            var songsA = iq.ToList();
            foreach (var song in songsA)
            {
                Console.WriteLine($"{song.Name} => {song.SourceItemId}");
            }

            //IV. Types of Loading. Lazy, Eager and Explicit Loading + SELECT. If we need some data use SELECT is the best, then loading!!!
            //What kind of access we have if we take a DbSet Songs?
            //- All properties, but there is no navigation properies, if we don't use projection:
            var songs9 = db.Songs.Where(x => x.Id <= 10).ToList();
            foreach (var song in songs9)
            {
                Console.WriteLine(song.Name);//This we have
                Console.WriteLine(song.Source.Name); //This we don't have access to it
            }

            //1. Select - projection. All properties, if we use projection - we can use navigation properties, but we have only the info we have written in the Select:
            var songs10 = db.Songs
                .Where(x => x.Id <= 10)
                .Select(x => new
                {
                    Name = x.Name,
                    SourceName = x.Source.Name,
                })
                .ToList();

            foreach (var song in songs10)
            {
                Console.WriteLine(song.Name);//This we have
                Console.WriteLine(song.SourceName); //This we have now, but we have only two lines, which are in Select
            }

            //2. Explicit Loading. It's used very rare:
            var songs11 = db.Songs
                .Where(x => x.Id <= 10)
                .ToList();
            foreach (var song in songs11)
            {
                Console.WriteLine(song.Name);//This we have

                db.Entry(song).Reference(x => x.Source).Load();//Adding Reference to Entry song
                Console.WriteLine(song.Source.Name); //This we have now too

                db.Entry(song).Collection(x => x.SongArtists).Load();//Adding Collection to Entry song
                Console.WriteLine(song.SongArtists.Count());//This we have now too
            }

            //3. Eager Loading. With .Include and .ThenInclude - we are making JOINS in SQL of all table we include with all data for them!
            var songs12 = db.Songs
                .Include(x => x.Source)
                .Include(x => x.SongArtists)
                .ThenInclude(x => x.Artist)
                .Where(x => x.Id <= 10)
                .ToList();
            foreach (var song in songs12)
            {
                Console.WriteLine(song.Name);//This we have
                Console.WriteLine(song.Source.Name); //This we have now too - because of .Include(x => x.Source)
                Console.WriteLine(song.SongArtists.Count());//This we have now too - because of .Include(x => x.SongArtists)
            }

            //4. Lazy Loading. NOT recommended! It is like Explicit, but we don't write it - EF is doing instead of us. Need 3 steps:
            //4.1 All navigational properties in the entities we create - SHOULD be virtual
            //4.2 Install packege - Microsoft.EntityFrameworkCore.Proxies
            //4.3 In the DbContext in the method OnConfiguring to add .UseLazyLoadingProxies() like this: 
            //optionsBuilder
            //       .UseLazyLoadingProxies()
            //       .UseSqlServer("Server=.;Database=MusicX;Integrated Security=true");
            //4.31 n + 1 effect
            var songs13 = db.Songs
                .Where(x => x.Id <= 10)//But to the SQL server we will send 10 + 1 queries in the foreach
                .ToList();
            foreach (var song in songs13)
            {
                Console.WriteLine(song.Name);//This we have
                Console.WriteLine(song.Source.Name); //This we have now too, because of the 3 steps we have done 
            }

            //4.32 n + 1 effect - solution - in this case we SHOULD use Select, not to have the n + 1 effect
            //We can use it when we are not going deep, so will not have many queries!
            var songs14 = db.Songs
                .Where(x => x.Id <= 10)// Here we will send to the SQL server only 1 query
                  .Select(x => new
                  {
                      Name = x.Name,
                      SourceName = x.Source.Name,
                      Arists = string.Join(", ", x.SongArtists.Select(a => a.Artist.Name)),
                  })
                .ToList();
            foreach (var song in songs14)
            {
                Console.WriteLine(song.Name);//This we have
                Console.WriteLine(song.SourceName); //This we have now too, because of the 3 steps we have done 
            }

            //IMPORTANT - the order we should use (from excellent to not recommended schale)
            //1. Select
            //2. Eager loading (.Include, .ThenInclude)
            //3. Lazy loading
            //4. Explicit loading
            //From 2 to 4 we have tracking changes, cause we don't have select!

            //5. Concurrency Checks. When we have two or more programs/people who read and write information (parallel).
            //The problem:
            var db1 = new MusicXContext();
            var artist1 = db1.Artists.FirstOrDefault(x => x.Id == 1);
            var db2 = new MusicXContext();
            var artist2 = db2.Artists.FirstOrDefault(x => x.Id == 1);
            artist1.MoneyEarned += 1000;
            artist2.MoneyEarned += 1000;
            db1.SaveChanges();
            db2.SaveChanges();
            //Should expect to have 2000, but actually - it will be only 1000, cause it saves changes of the last on, who took 0 balance + 1000 = 1000;
            //How to solve the problem:
            //To write the data by ourselves - not very convinient.
            //5.1. UPDATE Artists SET MoneyEarned = MoneyEarned + 1000 WHERE Id = 1
            //5.2. There is a attribute, we can use for MoneyEarned, so it will make sure if someone has made a change before me, to take it and then make my changes. This attribute is [ConcurrencyCheck] and the following code:
            var db11 = new MusicXContext();
            var artist11 = db1.Artists.FirstOrDefault(x => x.Id == 1);
            var db22 = new MusicXContext();
            var artist22 = db2.Artists.FirstOrDefault(x => x.Id == 1);
            artist11.MoneyEarned += 1000;
            db1.SaveChanges();
            while (true)
            {
                try
                {
                    artist22.MoneyEarned += 1000;
                    db22.SaveChanges();
                    break;
                }
                catch
                {
                    db22 = new MusicXContext();
                    artist22 = db2.Artists.FirstOrDefault(x => x.Id == 1);
                }
            }

            //6.Cascade Deletion - is a default one!!!
            //Cascade Delete with Fluent API(1)
            //Using OnDelete with DeleteBehavior Enumeration:
            //DeleteBehavior.Cascade
            //Deletes related entities(default for required FK)
            //    DeleteBehavior.Restrict
            //Throws exception on delete
            //    DeleteBehavior.ClientSetNull
            //Default behavior for optional FK (does not affect database)
            //    DeleteBehavior.SetNull
            //Sets the property to null(affects database)
            var song2 = db.Songs.FirstOrDefault(x => x.Id == 25);
            //var artist4 = db.Artists.Find(25);
            db.Songs.Remove(song2);//As our default is set in API to .OnDelete(DeleteBehavior.ClientSetNull); But if they are cascade - the song will be deleted and all connected with it lines in other tables will be deleted.
            //modelBuilder.Entity<Song>()
            //    .HasMany(x => x.SongArtists)
            //    .WithOne(x => x.Song)
            //    .OnDelete(DeleteBehavior.Cascade);
            //If API is set to .OnDelete(DeleteBehavior.ClientSetNull);.OnDelete(DeleteBehavior.SetNull);, we need the foreign keys to be nullable the deletetion to work!!!
            db.SaveChanges();
        }
    }
    class Projection
    {
        public string Name { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}