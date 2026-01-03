public class Menu
{
    private List<Song> library;
    private LinkedList playlist;
    private PlaybackSimulation playback;

    public Menu(List<Song> library, LinkedList playlist, PlaybackSimulation playback)
    {
        this.library = library;
        this.playlist = playlist;
        this.playback = playback;
    }

    public void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Main menu.");
            Console.WriteLine("1. Play song.");
            Console.WriteLine("2. Play playlist.");
            Console.WriteLine("3. Manage playlist.");
            Console.WriteLine("4. Exit");
            Console.Write("\nEnter choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    PlaySong();
                    break;
                case "2":
                    Playing();
                    break;
                case "3":
                    Manage();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void PlaySong()
    {
        Console.Clear();
        Console.WriteLine("Select a song to play\n");

        int i = 0;
        while (i < library.Count)
        {
            Console.WriteLine($"{i + 1}. {library[i].Title} - {library[i].Artist}");
            i++;
        }
        i++;
        Console.WriteLine($"{i}. Exit");
        Console.Write("\nEnter song number: ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            if (choice == i)
                return;

            if (choice >= 1 && choice <= library.Count)
            {
                Song selected = library[choice - 1];
                PlayingSingle(selected);  // Call the new method
            }
            else
            {
                Console.WriteLine("Invalid selection!");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("Invalid input!");
            Console.ReadKey();
        }
    }

    private void PlayingSingle(Song song)
    {
        bool looping = false;

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Now playing: {song.Title}");
            Console.WriteLine($"Artist: {song.Artist}");
            Console.WriteLine($"Duration: {song.Duration}");
            Console.WriteLine($"Loop: {(looping ? "ON" : "OFF")}");
            Console.WriteLine("\n1. Toggle loop");
            Console.WriteLine("2. Exit");
            Console.Write("\nEnter choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    looping = !looping;
                    break;
                case "2":
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void Playing()
    {
        if (!playback.Start())
        {
            Console.WriteLine("Playlist is empty!");
            Console.ReadKey();
            return;
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Now playing: {playback.CurrentSong.Title} By: {playback.CurrentSong.Artist}");
            Console.WriteLine($"Duration: {playback.CurrentSong.Duration}");
            Console.WriteLine($"Loop: {(playback.IsLooping ? "ON" : "OFF")}");
            Console.WriteLine("\n1. Next");
            Console.WriteLine("2. Previous");
            Console.WriteLine("3. Toggle loop");
            Console.WriteLine("4. Play next (queue)");
            Console.WriteLine("5. Exit");
            Console.Write("\nEnter choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    playback.Next();
                    break;
                case "2":
                    playback.Previous();
                    break;
                case "3":
                    playback.ToggleLoop();
                    break;
                case "4":
                    QueueSong();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void QueueSong()
    {
        Console.Clear();
        Console.WriteLine("Select a song to play next:\n");

        int i = 0;
        while (i < library.Count)
        {
            Console.WriteLine($"{i + 1}. {library[i].Title} - {library[i].Artist}");
            i++;
        }
        i++;
        Console.WriteLine($"{i}. Cancel");
        Console.Write("\nEnter song number: ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            if (choice == i)
                return;

            if (choice >= 1 && choice <= library.Count)
            {
                Song selected = library[choice - 1];

                if (playback.Queue(selected))
                    Console.WriteLine($"'{selected.Title}' will play next!");
                else
                    Console.WriteLine("Failed to queue song.");

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid selection!");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("Invalid input!");
            Console.ReadKey();
        }
    }

    private void Manage()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Playlist options");
            Console.WriteLine("Select an option: ");
            Console.WriteLine("1. Add song");
            Console.WriteLine("2. Delete song");
            Console.WriteLine("3. Display playlist");
            Console.WriteLine("4. Search playlist");
            Console.WriteLine("5. Shuffle playlist");
            Console.WriteLine("6. Sort playlist");
            Console.WriteLine("7. Import playlist");
            Console.WriteLine("8. Export playlist");
            Console.WriteLine("9. Exit");
            Console.Write("\nEnter choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Add();
                    break;
                case "2":
                    Delete();
                    break;
                case "3":
                    Display();
                    break;
                case "4":
                    Search();
                    break;
                case "5":
                    Shuffle();
                    break;
                case "6":
                    Sort();
                    break;
                case "7":
                    ImportPlaylist();
                    break;
                case "8":
                    ExportPlaylist();
                    break;
                case "9":
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    Console.ReadKey();
                    break;
            }
        }
    }
    private void Add()
    {
        Console.Clear();
        Console.WriteLine("Select a song to add:\n");

        int i = 0;
        while (i < library.Count)
        {
            Console.WriteLine($"{i + 1}. {library[i].Title} - {library[i].Artist}");
            i++;
        }
        i++;
        Console.WriteLine($"{i}. Exit");
        Console.Write("\nEnter song number: ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            if (choice == i)
                return;

            if (choice >= 1 && choice <= library.Count)
            {
                Song selected = library[choice - 1];

                if (playlist.Add(selected))
                {
                    Console.Clear();
                    Console.WriteLine($"Added '{selected.Title}' to playlist!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"'{selected.Title}' is already in the playlist!");
                }
            }
            else
            {
                Console.WriteLine("Invalid selection!");
            }
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }

        Console.ReadKey();
    }
    private void Delete()
    {
        while (true)
        {
            if (playlist.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Playlist is empty");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("Delete by?: ");
            Console.WriteLine("1. Title");
            Console.WriteLine("2. Postion");
            Console.WriteLine("3. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    TitleDelete();
                    break;
                case "2":
                    PositionDelete();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid selection");
                    Console.ReadKey();
                    break;

            }

        }

    }

    private void TitleDelete()
    {
        Console.Clear();
        Console.WriteLine("Enter a song title to delete (or 'exit' to cancel): ");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("No input provided!");
            Console.ReadKey();
            return;
        }

        if (input.ToLower() == "exit")
            return;

        if (playlist.Delete(input))
            Console.WriteLine($"Deleted '{input}' from playlist!");
        else
            Console.WriteLine("Song not found");

        Console.ReadKey();

        if (playlist.Count == 0)
        {
            return;
        }
    }

    private void PositionDelete()
    {
        Console.Clear();
        Console.WriteLine("Delete song by position\n");

        playlist.Print();

        Console.WriteLine($"\nEnter position to delete (1-{playlist.Count}), or -1 to cancel: ");

        if (int.TryParse(Console.ReadLine(), out int index))
        {
            if (index == -1)
                return;

            if (playlist.Delete(index - 1))
                Console.WriteLine($"Deleted song at position {index}!");
            else
                Console.WriteLine("Invalid position!");
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }

        Console.ReadKey();

        if (playlist.Count == 0)
        {
            return;
        }
    }

    private void Display()
    {
        if (playlist.Count == 0)
        {
            Console.Clear();
            Console.WriteLine("Playlist is empty");
            Console.ReadKey();
            return;
        }
        Console.Clear();
        Console.WriteLine("Current playlist: \n");
        playlist.Print();
        Console.Write("\nPress any key to continue..");
        Console.ReadKey();
    }

    private void Search()
    {
        Console.Clear();
        Console.WriteLine("Enter song title to search (or 'exit' to cancel): ");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("No input provided!");
            Console.ReadKey();
            return;
        }

        if (input.ToLower() == "exit")
            return;

        int position = playlist.Search(input);

        if (position >= 0)
            Console.WriteLine($"'{input}' found at position {position + 1}");
        else
            Console.WriteLine("Song not found or playlist is empty!");

        Console.ReadKey();
    }

    private void Shuffle()
    {
        Console.Clear();
        if (playlist.Count == 0)
        {
            Console.Clear();
            Console.WriteLine("Playlist is empty");
            Console.ReadKey();
            return;
        }

        if (playlist.ShuffleList())
        {
            Console.Clear();
            Console.WriteLine("Playlist has been shuffled: \n");
            playlist.Print();
        }
        else
        {
            Console.WriteLine("\nUnable to shuffle");
        }
        Console.Write("\nPress any key..");
        Console.ReadKey();
        return;
    }

    private void Sort()
    {
        if (playlist.Count == 0)
        {
            Console.Clear();
            Console.WriteLine("Playlist is empty!");
            Console.ReadKey();
            return;
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Sort options");
            Console.WriteLine("1. Sort by artist");
            Console.WriteLine("2. Sort by duration");
            Console.WriteLine("3. Exit");
            Console.Write("\nEnter choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    playlist.SortByArtist();
                    Console.WriteLine("Sorted by artist: ");
                    playlist.Print();
                    Console.Write("\nPress any key...");
                    Console.ReadKey();
                    return;
                case "2":
                    Console.Clear();
                    playlist.SortByDuration();
                    Console.WriteLine("Sorted by duration: ");
                    playlist.Print();
                    Console.Write("\nPress any key...");
                    Console.ReadKey();
                    return;
                /*
                case "X3":
                    playlist.SortByTitle();
                    Console.WriteLine("Sorted by title!");
                    Console.ReadKey();
                    break;
                */
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void ExportPlaylist()
    {
        if (playlist.Count == 0)
        {
            Console.Clear();
            Console.WriteLine("Playlist is empty!");
            Console.ReadKey();
            return;
        }

        Console.Clear();
        Console.WriteLine("Enter filename to export (without .csv): ");
        string? filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("No filename provided!");
            Console.ReadKey();
            return;
        }

        try
        {
            using (StreamWriter writer = new StreamWriter($"{filename}.csv"))
            {
                writer.WriteLine("ID,Title,Artist,Album,Duration,Genre");  // Header

                Node? current = playlist.Head;
                while (current != null)
                {
                    Song s = current.SongData;
                    writer.WriteLine($"{s.ID},{s.Title},{s.Artist},{s.Album},{s.Duration},{s.Genre}");
                    current = current.Next;
                }
            }

            Console.WriteLine($"Playlist exported to {filename}.csv!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Export failed: {ex.Message}");
        }

        Console.ReadKey();
    }

    private void ImportPlaylist()
    {
        Console.Clear();
        Console.WriteLine("Enter filename to import (without .csv): ");
        string? filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("No filename provided!");
            Console.ReadKey();
            return;
        }

        if (!File.Exists($"{filename}.csv"))
        {
            Console.WriteLine("File not found!");
            Console.ReadKey();
            return;
        }

        try
        {
            List<Song> importedSongs = Song.ImportSongs($"{filename}.csv");
            int added = 0;
            int skipped = 0;

            foreach (Song song in importedSongs)
            {
                if (playlist.Add(song))
                    added++;
                else
                    skipped++;
            }

            Console.WriteLine($"Imported {added} songs. Skipped {skipped} duplicates.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Import failed: {ex.Message}");
        }

        Console.ReadKey();
    }
}