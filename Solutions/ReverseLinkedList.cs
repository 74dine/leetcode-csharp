namespace LeetcodeCSharp;

public class ReverseLinkedList
{
    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once MemberCanBeMadeStatic.Global
#pragma warning disable CA1822
    public ListNode ReverseList(ListNode head)
    {
        ListNode? current = head;
        ListNode? previous = null;

        while (current != null)
        {
            var next = current.next;

            current.next = previous;
            previous = current;
            current = next;
        }

        return previous!;
    }
#pragma warning restore CA1822


    [Fact]
    public void LC_Case_1()
    {
        Assert.Equal(ListNode.FromList([5, 4, 3, 2, 1]), ReverseList(ListNode.FromList([1, 2, 3, 4, 5])!));
    }

    [Fact]
    public void LC_Case_2()
    {
        Assert.Equal(ListNode.FromList([1, 2]), ReverseList(ListNode.FromList([2, 1])!));
    }

    [Fact]
    public void Does_handle_empty_lists()
    {
        Assert.Equal(new ListNode(), ReverseList(new ListNode()));
    }

    [Fact]
    public void Does_handle_single_element()
    {
        Assert.Equal(new ListNode(5), ReverseList(new ListNode(5)));
    }

    public class ListNode(int val = 0, ListNode? next = null)
    {
        private readonly int val = val;
        public ListNode? next = next;

        public static ListNode? FromList(ICollection<int> values)
        {
            ListNode? head = null;
            ListNode? tail = null;

            foreach (var value in values)
            {
                var node = new ListNode(value);

                if (head is null)
                {
                    head = node;
                }
                else
                {
                    tail!.next = node;
                }

                tail = node;
            }

            return head;
        }

        public override bool Equals(object? obj)
        {
            return obj is ListNode listNode && Equals(listNode);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(val, next);
        }

        private bool Equals(ListNode? other)
        {
            return other is not null
                   && val == other.val
                   && Equals(next, other.next);
        }

        public override string ToString()
        {
            var values = new List<int>();

            for (var node = this; node != null; node = node.next)
                values.Add(node.val);

            return string.Join(" -> ", values);
        }
    }
}