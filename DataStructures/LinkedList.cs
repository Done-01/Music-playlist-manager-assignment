using System.Transactions;

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

    private readonly Dictionary<string, Node> titleHash;

    public LinkedList()
    {
        head = null;
        tail = null;
        count = 0;
        totalDuration = new TimeSpan();
        titleHash = new Dictionary<string, Node>();
    }

    public void Add(Song song)
    {
        if (song == null)
        {
            throw new ArgumentNullException(nameof(song));
        }

        if (titleHash.ContainsKey(song.Title))
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
        totalDuration = totalDuration + song.Duration;
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

    public void Delete(int index)
    {
        if (head == null)
        {
            throw new Exception("List contains no nodes");
        }
        if (index < 0 || index >= count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
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

    public void Print()
    {
        Node? current = head;

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"{i}. {current.SongData.Title}");
            current = current.Next;
        }
    }

    public void Test()
    {
        Node[] result = MergeSort.Split(head);
        Console.WriteLine($"{result[0]}\n{result[1]}");
    }


    // recursion testing
    public int CountNodesHelp(Node current)
    {
        if (current == null) return 0;
        return 1 + CountNodesHelp(current.Next);
    }

    public int CountNodes()
    {
        return CountNodesHelp(head);
    }

}