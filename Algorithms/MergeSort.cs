public class MergeSort
{
    public static Node FindMiddle(Node head)
    {
        if (head == null)
        {
            throw new ArgumentNullException(nameof(head));
        }

        if (head.Next == null)
        {
            return head;
        }

        Node slow = head;
        Node fast = head.Next;

        while (fast != null && fast.Next != null)
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
            throw new ArgumentNullException(nameof(head));
        }

        if (head.Next == null)
        {
            return [head, null];
        }

        Node middle = FindMiddle(head);
        
        Node left = head;
        Node right = middle.Next;

        // Need to cut lNode tail from rNode head
        middle.Next = null;
        right.Previous = null;

        // redundant but leave for now
        left.Previous = null;

        // test
        Node testLeft = left;
        Console.WriteLine("Left half: ");
        while (testLeft != null)
        {
            Console.WriteLine(testLeft);
            testLeft = testLeft.Next;
        }

        Node testRight = right;
        Console.WriteLine("Right half: ");
        while (testRight != null)
        {
            Console.WriteLine(testRight);
            testRight = testRight.Next;
        }

        return [left, right];

    }

    public static Node Merge(Node left, Node right)
    {
        if (left == null)
        {
            return right;
        }
        if (right == null)
        {
            return left;
        }

        string leftTitle = left.SongData.Title;
        string rightTitle = right.SongData.Title;

        Node mergedResult;

        if (string.Compare(leftTitle, rightTitle) <= 0)
        {
            mergedResult = left;
            mergedResult.Next = Merge(left.Next, right);
            if (mergedResult.Next != null)
            {
                mergedResult.Next.Previous = mergedResult;
            }
        }
        else
        {
            mergedResult = right;
            mergedResult.Next = Merge(left, right.Next);
            if (mergedResult.Next != null)
            {
                mergedResult.Next.Previous = mergedResult;
            }

        }

        return mergedResult;
    }

    public static Node Sort(Node head)
    {
        if (head == null || head.Next == null)
        {
            return head;
        }

        Node[] split = Split(head);

        //recursion starts here
        Node sortedLeft = Sort(split[0]);
        Node sortedRight = Sort(split[1]);

        return Merge(sortedLeft, sortedRight);

    }
}