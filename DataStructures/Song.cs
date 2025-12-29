public record Song
{
    public int ID {get;}
    public string Title {get;}
    public string Artist {get;}
    public string? Album {get;}
    public TimeSpan Duration {get;}
    public string Genre {get;}


    public Song (int id, string title, string artist, string? album, string genre, TimeSpan duration)
    {
        ID = id;
        Title = title;
        Artist = artist;
        Album = album;
        Duration = duration;
        Genre = genre;
    }

    public static void ImportSongs(string fileLocation)
    {
       foreach(var line in File.ReadLines(fileLocation).Skip(1))
        {
            Console.WriteLine(line);
        }

    }
}