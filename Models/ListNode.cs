namespace LeetcodeCSharp.Models;

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