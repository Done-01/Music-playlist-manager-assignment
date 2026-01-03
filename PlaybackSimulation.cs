public class PlaybackSimulation
{
    private LinkedList playlist;
    private Node? currentNode;
    private Node? queuedNode;
    private bool isLooping;

    public Song? CurrentSong
    {
        get { return currentNode?.SongData; }
    }

    public bool IsLooping
    {
        get { return isLooping; }
    }

    public bool IsEmpty
    {
        get { return playlist.Head == null; }
    }

    public PlaybackSimulation(LinkedList playlist)
    {
        this.playlist = playlist;
        this.currentNode = null;
        this.queuedNode = null;
        this.isLooping = false;
    }

    public bool Start()
    {
        if (playlist.Head == null)
            return false;

        currentNode = playlist.Head;
        return true;
    }

    public void ToggleLoop()
    {
        isLooping = !isLooping;
    }

    public void Next()
    {
        if (currentNode == null)
            return;

        if (isLooping)
            return;

        if (queuedNode != null)
        {
            currentNode = queuedNode;
            queuedNode = null;
        }
        else if (currentNode.Next != null)
        {
            currentNode = currentNode.Next;
        }
        else
        {
            currentNode = playlist.Head;
        }
    }

    public void Previous()
    {
        if (currentNode == null)
            return;

        if (isLooping)
            return;

        if (currentNode.Previous != null)
        {
            currentNode = currentNode.Previous;
        }
        else
        {
            currentNode = playlist.Tail;
        }
    }

    public bool Queue(Song song)
    {
        if (song == null || currentNode == null)
            return false;

        queuedNode = new Node(song);
        queuedNode.Next = currentNode.Next;
        return true;
    }
}