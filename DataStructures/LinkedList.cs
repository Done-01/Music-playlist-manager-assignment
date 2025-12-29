public class LinkedList
{
    private Node? head;
    private Node? tail;

    private int count;
    public int Count
    {
        get { return count; }
    }

    private TimeSpan totalDuration;
    public TimeSpan TotalDuration
    {
        get { return totalDuration; }
    }

    private readonly Dictionary<int, Node> idHash;
    private readonly Dictionary<string, Node> titleHash;

    public LinkedList()
    {
        head = null;
        tail = null;
        count = 0;
        totalDuration = new TimeSpan();
        idHash = new Dictionary<int, Node>();
        titleHash = new Dictionary<string, Node>();
    }

    public void Add(Song song)
    {
        if (song == null)
        {
            throw new ArgumentNullException(nameof(song));
        }

        if (idHash.ContainsKey(song.ID) || titleHash.ContainsKey(song.Title))
        {
            throw new Exception("Duplicate Song");
        }

        Node newNode = new Node(song);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail!.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
        }

        count++;
        totalDuration = totalDuration - song.Duration;
        idHash.Add(song.ID, newNode);
        titleHash.Add(song.Title, newNode);
    }

    public void Delete(string songTitle)
    {
        if (head == null)
        {
            throw new Exception("List contains no nodes");
        }
        if (!titleHash.TryGetValue(songTitle, out Node? node))
        {
            throw new Exception("Song title not present in list");
        }

        DeleteNode(node);
    }

        public void Delete(int songId)
    {
        if (head == null)
        {
            throw new Exception("List contains no nodes");
        }
        if (!idHash.TryGetValue(songId, out Node? node))
        {
            throw new Exception("Song id not present in list");
        }

        DeleteNode(node);
    }

    public void DeleteNode(Node node)
    {
        // Delete by title

        // 4 states for a node to be deleted
        // 1. Single node
        // 2. Head node with a next node
        // 3. Middle node (has both next and prev)
        // 4. Tail node with a previous node

        // 1.
        
        if (node.Next == null && node.Previous == null)
        {
            head = null;
            tail = null;
        }
        // 2.
        else if (node.Previous == null)
        {
            head = node.Next;
            node.Next!.Previous = null;
        }
        // 4.
        else if (node.Next == null)
        {
            tail = node.Previous;
            node.Previous.Next = null;
        }
        // 3.
        else
        {
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
        }

        node.Next = null;
        node.Previous = null;

        count--;
        totalDuration = totalDuration + node.SongData.Duration;
        idHash.Remove(node.SongData.ID);
        titleHash.Remove(node.SongData.Title);
    }

    public static void Sort(LinkedList list)
    {
        // Sort by title / duration
    }

}