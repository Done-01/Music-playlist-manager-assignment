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

        /* test
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
        */

        return [left, right];

    }
    // Code for sorting by title.
    public static Node MergeByTitle(Node left, Node right)
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
            mergedResult.Next = MergeByTitle(left.Next, right);
            if (mergedResult.Next != null)
            {
                mergedResult.Next.Previous = mergedResult;
            }
        }
        else
        {
            mergedResult = right;
            mergedResult.Next = MergeByTitle(left, right.Next);
            if (mergedResult.Next != null)
            {
                mergedResult.Next.Previous = mergedResult;
            }

        }

        return mergedResult;
    }

    public static Node SortByTitle(Node head)
    {
        if (head == null || head.Next == null)
        {
            return head;
        }

        Node[] split = Split(head);

        Node sortedLeft = SortByTitle(split[0]);
        Node sortedRight = SortByTitle(split[1]);

        return MergeByTitle(sortedLeft, sortedRight);

    }

    // Code for sorting by duration.
        public static Node MergeByDuration(Node left, Node right)
    {
        if (left == null)
        {
            return right;
        }
        if (right == null)
        {
            return left;
        }

        TimeSpan leftDuration = left.SongData.Duration;
        TimeSpan rightDuration = right.SongData.Duration;

        Node mergedResult;

        if (leftDuration <= rightDuration)
        {
            mergedResult = left;
            mergedResult.Next = MergeByDuration(left.Next, right);
            if (mergedResult.Next != null)
            {
                mergedResult.Next.Previous = mergedResult;
            }
        }
        else
        {
            mergedResult = right;
            mergedResult.Next = MergeByDuration(left, right.Next);
            if (mergedResult.Next != null)
            {
                mergedResult.Next.Previous = mergedResult;
            }

        }

        return mergedResult;
    }

    public static Node SortByDuration(Node head)
    {
        if (head == null || head.Next == null)
        {
            return head;
        }

        Node[] split = Split(head);

        Node sortedLeft = SortByDuration(split[0]);
        Node sortedRight = SortByDuration(split[1]);

        return MergeByDuration(sortedLeft, sortedRight);
    }
}