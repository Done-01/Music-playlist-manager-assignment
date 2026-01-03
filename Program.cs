
string filePath = "Files/songs_dataset.csv";
List<Song> library = Song.ImportSongs(filePath);

LinkedList playlist = new LinkedList();

foreach (Song song in library)
{
    playlist.Add(song);
}


// playlist.Add(library[1]);

PlaybackSimulation playback = new PlaybackSimulation(playlist);

Menu menu = new Menu(library,playlist,playback);

menu.MainMenu();




