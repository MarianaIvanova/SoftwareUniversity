namespace MusicHub.Data
{
   public static class Configuration
    {
        public static string ConnectionString =
            @"Server=.;Database=MusicHub;Trusted_Connection=True";
        //optionsBuilder.UseSqlServer("Server=.;Database=MusicHub;Integrated Security=true");
    }
}
