
string filePath = "Files/songs_dataset.csv";
List<Song> songs = Song.ImportSongs(filePath);

LinkedList playlist = new LinkedList();

foreach(Song song in songs)
{
    playlist.Add(song);
}

playlist.Print();

playlist.ShuffleList();

playlist.Print();

playlist.ShuffleList();

playlist.Print();

/*
playlist.DurationTest();

playlist.TitleTest();


static void PrintA(int[] array)
{
    for(int i = 0; i < array.Count(); i++)
    {
        Console.Write($"{array[i]} ");
    }

    Console.WriteLine();
}

int[] array = {1,2,3,4,5,6,7,8,9,10};

PrintA(array);

Shuffle.Shufflez(array);

PrintA(array);
*/

