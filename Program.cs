string filePath = "Files/songs_dataset.csv";
List<Song> songs = Song.ImportSongs(filePath);

LinkedList playlist = new LinkedList();

foreach(Song song in songs)
{
    playlist.Add(song);
}

/*
playlist.Add(songs[0]);
playlist.Add(songs[1]);
*/

playlist.Print();

playlist.Test3();

playlist.Print();
