using LINQ_2_Lab_Linq_IQueryable.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Should insall for every project:
//Microsoft.EntityFrameworkCore.SqlServer 3.1.3 - for lecture - we use 5.0.3
//Microsoft.EntityFrameworkCore.Design 3.1.3 - for lecture - we use 5.0.3
//Part of 5. LINQ

namespace LINQ_2_Lab_Linq_IQueryable
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;//using System.Text;
            var db = new MusicXContext();
            //Count 
            Console.WriteLine(db.Songs.Count());//50021 
            //We can make a list with all songs for example. It will put info for all 50ths songs in the list with info about the primitive types prop of the song, but not for the collections in it.
            var songs = db.Songs.ToList();// DON'T RUN this

            //  ACTIONS
            //1 Where
            //1.1
            var songsA = db.Songs.Where(x => x.Name.StartsWith("Z")).ToList();
            Console.WriteLine(songsA.Count());//257 - this is the query from SQL Server Profiler:
            /*
            SELECT[s].[Id], [s].[CreatedOn], [s].[DeletedOn], [s].[IsDeleted], [s].[ModifiedOn], [s].[Name], [s].[SearchTerms], [s].[SourceId], [s].[SourceItemId]
                FROM[Songs] AS[s]
             WHERE[s].[Name] LIKE N'Z%'
            */

            //1.2
            Console.WriteLine(db.Songs.Count(x => x.Name.StartsWith("Z")));//257 - here we don't even take the data for the songs - only their count
            /*
             SELECT COUNT(*)
                FROM [Songs] AS [s]
                WHERE [s].[Name] LIKE N'Z%'
             */

            //1.3
            var songs2 = db.Songs
                .Where(x => x.Source.Name == "User")
                .ToList();
            foreach (var song in songs2)
            {
                Console.WriteLine(song.Name);
            }
            /*
             SELECT [s].[Id], [s].[CreatedOn], [s].[DeletedOn], [s].[IsDeleted], [s].[ModifiedOn], [s].[Name], [s].[SearchTerms], [s].[SourceId], [s].[SourceItemId]
                FROM [Songs] AS [s]
                LEFT JOIN [Sources] AS [s0] ON [s].[SourceId] = [s0].[Id]
                WHERE [s0].[Name] = N'User'
             */
            //Писна ми
            //Затова
            //Dobro da nije vece zlo
            //Thelo na me nioseis
            //...

            //2 Select
            var songs3 = db.Songs
                .Where(x => x.Source.Name == "User")
                .Select(x => new
                {
                    Name = x.Name,
                    Source = x.Source.Name,
                    Artist = string.Join(", ", x.SongArtists.Select(a => a.Artist.Name)),
                })
                .ToList();
            foreach (var song in songs3)
            {
                Console.WriteLine($"{song.Artist} - {song.Name}");
            }
            /*
                SELECT [s].[Name], [s0].[Name], [s].[Id], [s0].[Id], [t].[Name], [t].[Id], [t].[Id0]
                FROM [Songs] AS [s]
                LEFT JOIN [Sources] AS [s0] ON [s].[SourceId] = [s0].[Id]
                LEFT JOIN (
                    SELECT [a].[Name], [s1].[Id], [a].[Id] AS [Id0], [s1].[SongId]
                    FROM [SongArtists] AS [s1]
                    INNER JOIN [Artists] AS [a] ON [s1].[ArtistId] = [a].[Id]
                ) AS [t] ON [s].[Id] = [t].[SongId]
                WHERE [s0].[Name] = N'User'
                ORDER BY [s].[Id], [s0].[Id], [t].[Id], [t].[Id0]
             */
            /*
            Спенс - Писна ми
            Слави, Ку - Ку Бенд - Затова
            Lexington - Dobro da nije vece zlo
            */

            //2.1 No .Select()
            //---1. (-) No access to navigational properties
            //(there is a way, but it's advanced - with lazy loading or include)
            //---2. (-) Get all columns for the entity
            //(but if we don't need them all - not optimal RAM)
            //---3. (+) update/ delete entity / db.SaveChanges();

            var songs4 = db.Songs
                .Where(x => x.Source.Name == "User")
                .ToList();
            foreach (var song in songs4)
            {
                song.ModifiedOn = DateTime.UtcNow;
            }
            db.SaveChanges();

            //2.2 With .Select() => anonymus type
            //---1. (+) Access to navigational properties in Lambda
            //---2. (+) Get only the columns we need
            //---3. (-) No update/ delete

            var songs5 = db.Songs
                .Where(x => x.Source.Name == "User")
                .Select(x => new
                {
                    Name = x.Name,
                    SourceName = x.Source.Name,
                    ArtistsCount = x.SongArtists.Count()
                })
                .ToList();
            foreach (var song in songs5)
            {
                Console.WriteLine($"{song.Name} => {song.ArtistsCount} => {song.SourceName}");
            }

            //3. Aggregation functions = Group by in SQL
            //3.1 Average
            Console.WriteLine(db.Artists.Where(x => x.Name.StartsWith("A")).Average(x => x.Id));//9374.857902735563

            //3.2 Count
            Console.WriteLine(db.Artists.Where(x => x.Name.StartsWith("A")).Count());//1316

            //3.3 Max and Min
            Console.WriteLine(db.Artists.Where(x => x.Name.StartsWith("A")).Min(x => x.Name));//A
            Console.WriteLine(db.Artists.Where(x => x.Name.StartsWith("A")).Max(x => x.Name));//Azzi Memo

            //3.4 Sum
            Console.WriteLine(db.Artists.Where(x => x.Name.StartsWith("A")).Sum(x => x.Id));//12337313

            //3.1-4 - we can use all of them in these cases. In Select, in Where, have conditions in Count, Max, AVG Sum
            var artists = db.Artists
                .OrderByDescending(x => x.SongArtists.Count())
                .Where(x => x.SongArtists.Count(a => a.Song.Name.Contains("a")) > 50)
                .Select(x => new
                {
                    Name = x.Name,
                    Count = x.SongArtists.Count(),
                    CountA = x.SongArtists.Count(b => b.Song.Name.Contains("a")),
                })
                .Take(10)
                //.OrderByDescending(x => x.CountA / x.Count) //to order by x.CountA / x.Count
                .ToList();
            foreach (var artist in artists)
            {
                Console.WriteLine(artist.Name + " " + artist.Count + " " + artist.CountA);
                Console.WriteLine(artist);//There is a method for override this!!!
            }
            //Soundtrack 211 164
            //{ Name = Soundtrack, Count = 211, CountA = 164 }
            //Drake 128 66
            //{ Name = Drake, Count = 128, CountA = 66 }
            //...

            //4. INNER JOIN table. If we don't want the Join to be Left Join, we can write it by ourselves:
            //will show the songs - which have source only!
            var songs6 = db.Songs.Join(
                db.Sources,
                x => x.SourceId,
                x => x.Id,
                (song, source) => new
                {
                    SongName = song.Name,
                    SourceName = source.Name,
                })
              .ToList();
            foreach (var song in songs6)
            {
                Console.WriteLine(song.SongName + " => " + song.SourceName);
            }
            // LEFT JOIN - regular one - will show ALL songs - it doesn't matter if they have source or not:
            var songs7 = db.Songs.Select(x => new
            {
                SongName = x.Name,
                SourceName = x.Source.Name,
            })
              .ToList();
            // INNER JOIN - the same as above code with a little but change + .Where(x => x.Source != null)
            var songs8 = db.Songs.Where(x => x.Source != null).Select(x => new
            {
                SongName = x.Name,
                SourceName = x.Source.Name,
            })
              .ToList();

            //5. Grouping + always ADD .Select with Aggregated functions
            var groups = db.Artists
                .GroupBy(x => x.Name.Substring(0, 1))//Group by the first letter if the name
                .Where(x => x.Count() >= 10)//This is something like having in SQL
                .Select(x => new //x here is the box
                {
                    FirstLetter = x.Key,
                    Count = x.Count(),
                    Min = x.Min(x => x.Name),
                    Max = x.Max(x => x.Name),
                })
                .ToList();

            foreach (var group in groups)
            {
                Console.WriteLine(group);
            }
            //{ FirstLetter = W, Count = 282, Min = W, Max = WZRD }
            //{ FirstLetter = U, Count = 112, Min = U$o, Max = Uwu Lena }
            //{ FirstLetter = O, Count = 270, Min = O, Max = Ozzy Osbourne } //...
            /*
             SELECT SUBSTRING([a].[Name], 0 + 1, 1) AS [FirstLetter], COUNT(*) AS [Count], MIN([a].[Name]) AS [Min], MAX([a].[Name]) AS [Max]
                FROM [Artists] AS [a]
                GROUP BY SUBSTRING([a].[Name], 0 + 1, 1)
                HAVING COUNT(*) >= 10
             */

            //6. SelectMany. Printout 6.1 = 6.2
            //6.1
            var artistsWithSongs = db.Artists
                .Select(x => x.SongArtists.Select(a => x.Name + " - " + a.Song.Name))
                .ToList();
            foreach (var songsB in artistsWithSongs)
            {
                foreach (var song in songsB)
                {
                    Console.WriteLine(song);
                }
            }
            //6.2
            var artistsWithSongs2 = db.Artists
                .SelectMany(x => x.SongArtists.Select(a => x.Name + " - " + a.Song.Name))
                .ToList();
            foreach (var song in artistsWithSongs2)
            {
                Console.WriteLine(song);
            }

            //7. Union() - обединение, Intersect() - сечение, -- not used in EF
            var artistsWithSongs3 = db.Artists
                .SelectMany(x => x.SongArtists.Select(a => x.Name + " - " + a.Song.Name))
                .Union(db.Sources.Select(x => x.Name))//will make union with songs names and sources
                .ToList();
            foreach (var song in artistsWithSongs3)
            {
                Console.WriteLine(song);
            }

            //8. IEnumerable and IQueryable. Till .ToList() is IQueryable - not real, we materialize it with .ToList() and make it IEnumerable
            //We materialize (from IQueryable to IEnumerable) with:
            //=> ToList(), ToArray(), ToDictionary() - collection
            //=> First / Last / Single or Default – like collection but only one element of it
            //=> Min, Max, Count, Average, Sum – aggregate functions
            //=> Foreach()

            var songs9 = db.Songs
                .Where(x => x.SongArtists.Count() == 1)
                .Skip(10000).Take(10)
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    Name = x.Name,
                    Artist = x.SongArtists.FirstOrDefault().Artist.Name,
                })
                .ToList();//No enougn memory

            //if we don't write .ToList(), we will materialize with:
            Console.WriteLine(songs9.Count());
            Console.WriteLine(songs9.Max(x => x.Name));

            //9. Result Models. They are anonymus classes or classes, created by us outside the DbSets with 
            //projection - .Selet() or .GroupBy(), they are totaly new models.

            var songs10 = db.Songs
                .Where(x => x.SongArtists.Count() == 1)
                .Skip(10000).Take(10)
                .OrderBy(x => x.Name)
                .Select(x => new ProjectionModel//Here we can have anonymus type too
                {
                    Name = x.Name,
                    Artist = x.SongArtists.FirstOrDefault().Artist.Name,
                })
                .ToList();

           //QUERY - only in version 5 works
           var songs11 = db.Songs
               .Where(x => x.SongArtists.Count() == 1)
               .Skip(10000).Take(10)
               .OrderBy(x => x.Name)
               .Select(x => new
               {
                   Name = x.Name,
                   Artist = x.SongArtists.FirstOrDefault().Artist.Name,
               });
            Console.WriteLine(songs11.ToQueryString());//using Microsoft.EntityFrameworkCore;
            /*
            DECLARE @__p_0 int = 10000;
            DECLARE @__p_1 int = 10;

            SELECT [t].[Name], (
                SELECT TOP(1) [a].[Name]
                FROM [SongArtists] AS [s]
                INNER JOIN [Artists] AS [a] ON [s].[ArtistId] = [a].[Id]
                WHERE [t].[Id] = [s].[SongId]) AS [Artist]
            FROM (
                SELECT [s0].[Id], [s0].[Name]
                FROM [Songs] AS [s0]
                WHERE (
                    SELECT COUNT(*)
                    FROM [SongArtists] AS [s1]
                    WHERE [s0].[Id] = [s1].[SongId]) = 1
                ORDER BY (SELECT 1)
                OFFSET @__p_0 ROWS FETCH NEXT @__p_1 ROWS ONLY
            ) AS [t]
            ORDER BY [t].[Name]
             */
        }

        public class ProjectionModel
        {
            public string Name { get; set; }
            public string Artist { get; set; }
        }
    }
}
