using System;
using System.Linq;

namespace MusicHub
{
    using System;
    using System.IO;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            ////Task 2
            //int producerId = 9;// int.Parse(Console.ReadLine());
            //Console.WriteLine(ExportAlbumsInfo(context, producerId));

            //Task 3
            var duration = 4;// int.Parse(Console.ReadLine());
            Console.WriteLine(ExportSongsAboveDuration(context, duration));
            //File.WriteAllText("../../../result.txt", result); //using System.IO;
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            //Mine
            var producer = context.Producers
                .Include(x => x.Albums)
                .ThenInclude(x => x.Songs)
                .FirstOrDefault(x => x.Id == producerId)
                .Albums
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    TotalPriceAlbum = a.Price,
                    AlbumSongs = a.Songs
                    .OrderByDescending(a => a.Name)
                    .ThenBy(a => a.Writer.Name)
                    .Select(b => new
                    {
                        SongName = b.Name,
                        SongPrice = b.Price,
                        SongWriterName = b.Writer.Name,
                    })
                })
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var album in producer)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");

                int count = 1;
                foreach (var song in album.AlbumSongs)
                {
                    sb.AppendLine($"---#{count}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.SongPrice:F2}");
                    sb.AppendLine($"---Writer: {song.SongWriterName}");
                    count++;
                }
                sb.AppendLine($"-AlbumPrice: {album.TotalPriceAlbum:F2}");
            }

            ////Teacher's:
            //var producer = context.Producers
            //    .FirstOrDefault(x => x.Id == producerId)
            //    .Albums
            //    .Select(album => new
            //    {
            //        AlbumName = album.Name,
            //        ReleaseDate = album.ReleaseDate,
            //        ProducerName = album.Producer.Name,
            //        AlbumSongs = album.Songs
            //        .Select(song => new
            //        {
            //            SongName = song.Name,
            //            SongPrice = song.Price,
            //            SongWriterName = song.Writer.Name,
            //        })
            //        .OrderByDescending(song => song.SongName)
            //        .ThenBy(song => song.SongWriterName)
            //        .ToList(),
            //        AlbumPrice = album.Price,
            //    })
            //    .OrderByDescending(x => x.AlbumPrice)
            //    .ToList();

            //StringBuilder sb = new StringBuilder();
            //foreach (var album in producer)
            //{
            //    sb.AppendLine($"-AlbumName: {album.AlbumName}")
            //      .AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy")}")
            //        .AppendLine($"-ProducerName: {album.ProducerName}")
            //        .AppendLine($"-Songs:");

            //    int count = 1;
            //    foreach (var song in album.AlbumSongs)
            //    {
            //        sb.AppendLine($"---#{count}")
            //            .AppendLine($"---SongName: {song.SongName}")
            //            .AppendLine($"---Price: {song.SongPrice:F2}")
            //            .AppendLine($"---Writer: {song.SongWriterName}");
            //        count++;
            //    }
            //    sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:F2}");
            //}

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            TimeSpan ts = TimeSpan.FromSeconds(duration);//convert int to TimeSpan//Mine

            var songs = context.Songs
                .Where(x => x.Duration > ts)//Mine - works!
                //.ToList()
                //.Where(x => x.Duration.TotalSeconds > duration)//Teacher to convert TimeSpan to Seconds, not OK in 3.1.3, so we should materialized the data with .ToList() before this.
                .Select(x => new
                {
                    SongName = x.Name,
                    PerformerFullName = x.SongPerformers
                             .Select(x => x.Performer.FirstName + " " + x.Performer.LastName)
                             .FirstOrDefault(),
                    Writer = x.Writer.Name,
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration,
                })
                .OrderBy(x => x.SongName)
                .ThenBy(x => x.Writer)
                .ThenBy(x => x.PerformerFullName)
                .ToList();

            StringBuilder sb = new StringBuilder();
            int count = 1;
            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{count++}")
                    .AppendLine($"---SongName: {song.SongName}")
                    .AppendLine($"---Writer: {song.Writer}")
                    .AppendLine($"---Performer: {song.PerformerFullName}")
                    .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.Duration:c}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
