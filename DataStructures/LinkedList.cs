public class LinkedList
{
    private Node? head;

    public Node? Head
    {
        get { return head; }
    }
    private Node? tail;

    public Node? Tail
    {
        get { return tail; }
    }

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

    private readonly Dictionary<string, Node> titleHash;

    public LinkedList()
    {
        head = null;
        tail = null;
        count = 0;
        totalDuration = new TimeSpan();
        titleHash = new Dictionary<string, Node>();
    }

    public bool Add(Song song)
    {
        if (song == null)
        {
            throw new ArgumentNullException(nameof(song));
        }

        if (titleHash.ContainsKey(song.Title))
        {
            return false;
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
        totalDuration = totalDuration + song.Duration;
        titleHash.Add(song.Title, newNode);
        return true;
    }

    public bool Delete(string songTitle)
    {
        if (head == null)
        {
            return false;
        }
        if (!titleHash.TryGetValue(songTitle, out Node? node))
        {
            return false;
        }

        DeleteNode(node);
        return true;
    }

    public bool Delete(int index)
    {
        if (head == null)
        {
            return false;
        }
        if (index < 0 || index >= count)
        {
            return false;
        }

        Node? current;

        if (index < count / 2)
        {
            current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next!;
            }
        }
        else
        {
            current = tail;
            for (int i = count - 1; i > index; i--)
            {
                current = current.Previous!;
            }
        }

        DeleteNode(current!);
        return true;
    }

    public void DeleteNode(Node node)
    {
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
        totalDuration = totalDuration - node.SongData.Duration;
        titleHash.Remove(node.SongData.Title);
    }

    public int Search(string songTitle)
    {
        if (head == null)
        {
            return -1;
        }
        if (!titleHash.TryGetValue(songTitle, out Node? node))
        {
            return -1;
        }

        Node? current = head;
        int i = 0;

        while (current != null)
        {
            if (current == node)
            {
                return i;
            }
            else
            {
                current = current.Next;
                i++;
            }
        }

        return -1; // hash table out of sync with linked list.
    }

    public bool ShuffleList()
    {
        if (head == null)
        {
            return false;
        }

        Node current = head;
        Song[] array = new Song[count];
        int i = 0;

        while (current != null && i < count)
        {
            array[i] = current.SongData;
            current = current.Next;
            i++;
        }

        Shuffle.FisherYates(array);

        Clear();

        for (int j = 0; j < array.Length; j++)
        {
            Add(array[j]);
        }
        return true;
    }
    public void Clear()
    {
        head = null;
        tail = null;
        count = 0;
        totalDuration = new TimeSpan();
        titleHash.Clear();
    }

    public void Print()
    {
        Node? current = head;

        int i = 1;
        while (current != null)
        {
            Console.WriteLine($"{i}. {current.SongData.Title} by {current.SongData.Artist} duration {current.SongData.Duration}");
            current = current.Next;
            i++;
        }
        Console.WriteLine($"Playlist total duration: {TotalDuration}");
        Console.WriteLine($"Playlist total count: {Count}");

    }
    public bool SortByArtist()
    {
        if (head == null)
            return false;

        head = MergeSort.SortByArtist(head);

        RebuildAfterSort();

        return true;
    }

    public bool SortByDuration()
    {
        if (head == null)
            return false;

        head = MergeSort.SortByDuration(head);

        RebuildAfterSort();

        return true;
    }
    private void RebuildAfterSort()
    {
        // Clear and rebuild hash table
        titleHash.Clear();

        Node? current = head;

        while (current != null)
        {
            titleHash.Add(current.SongData.Title, current);

            if (current.Next == null)
                tail = current;  

            current = current.Next;
        }
    }

}