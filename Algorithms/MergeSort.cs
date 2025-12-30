public class MergeSort
{
    public static Node FindMiddle(Node head)
    {
        Node slow = head;
        // changed from fast = head to fast = head.next
        Node fast = head.Next;

        while (fast.Next != null && fast.Next.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }

        return slow;
    }

    public static Node[] Split(Node head)
    {
        if (head == null)
        {
            throw new ArgumentNullException("Node cannot be null");
        }

        if (head.Next == null)
        {
            return [head,null];
        }

        Node middle = FindMiddle(head);
        Node left = head;
        Node right = middle.Next;

        // split into two
        right.Previous = null;
        middle.Next = null;

        // test
        Node testLeft = left;
        Node testRight = right;

        while(testLeft != null)
        {
            Console.WriteLine(testLeft);
            testLeft = testLeft.Next;
        }
        Console.WriteLine();
        while(testRight != null)
        {
            Console.WriteLine(testRight);
            testRight = testRight.Next;
        }
        Console.WriteLine();

        left = Split(left)[0];
        right = Split(right)[1];

        return [left,right];

    }
/*
    private static Node Merge(Node left, Node right)
    {
        string leftArtist = left.SongData.Artist;
        string rightArtist = right.SongData.Artist;

        if (left == null)
        {
            return right;
        }
        if (right == null)
        {
            return left;
        }

        Node mergedResult;

        if (string.Compare(leftArtist, rightArtist) <= 0)
        {
            mergedResult = left;
            mergedResult.Next = Merge(left.Next, right);
        }
        else
        {
            mergedResult = right;
            mergedResult.Next = Merge(left, right.Next);
        }

        return mergedResult;
    }
*/
}