public record Song
{
    public int ID {get;}
    public string Title {get;}
    public string Artist {get;}
    public string? Album {get;}
    public TimeSpan Duration {get;}
    public string Genre {get;}


    public Song (int id, string title, string artist, string? album, TimeSpan duration, string genre)
    {
        ID = id;
        Title = title;
        Artist = artist;
        Album = album;
        Duration = duration;
        Genre = genre;
    }

    public static List<Song> ImportSongs(string fileLocation)
    {
        List<Song> SongsList = new List<Song>();
        foreach(string line in File.ReadLines(fileLocation).Skip(1))
        {
            if(string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] songValues = line.Split(',');

            int id = int.Parse(songValues[0]);
            TimeSpan duration = TimeSpan.Parse(songValues[4]);

            Song newSong = new Song(id,songValues[1],songValues[2],songValues[3],duration,songValues[5]);

            SongsList.Add(newSong);
        }

        return SongsList;

    }
}