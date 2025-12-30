string filePath = "Files/songs_dataset.csv";
List<Song> songs = Song.ImportSongs(filePath);

LinkedList playlist = new LinkedList();

foreach(Song song in songs)
{
    playlist.Add(song);
}

playlist.Print();

playlist.Delete(0);
playlist.Delete("Bad Guy");
playlist.Delete(playlist.Count -1);
playlist.Print();

int count = playlist.CountNodes();

Console.WriteLine(count);