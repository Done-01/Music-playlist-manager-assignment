string filePath = "Files/songs_dataset.csv";
List<Song> songs = Song.ImportSongs(filePath);

LinkedList playlist = new LinkedList();

foreach(Song song in songs)
{
    playlist.Add(song);
}

playlist.Print();


// expected middle = hotel california
playlist.Sort();