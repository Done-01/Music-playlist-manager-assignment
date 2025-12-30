public class MergeSort
{
    public static Node FindMiddle(Node head)
    {
        Node slow = head;
        Node fast = head;

        while (slow.Next != null && fast.Next.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }

        return slow;
    }
/*
    private static Node[] Split(Node head)
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

        return [left,right];

    }

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