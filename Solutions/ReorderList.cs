using LeetcodeCSharp.Models;

using Xunit.Abstractions;

namespace LeetcodeCSharp.Solutions;

public class ReorderListQ(ITestOutputHelper _out)
{
    public void ReorderList(ListNode node)
    {
        ListNode? slow = node;
        ListNode? fast = node;
        while (fast?.next is not null)
        {
            slow = slow!.next;
            fast = fast.next.next;
        }

        ListNode? current = slow;
        ListNode? previous = null;

        while (current != null)
        {
            ListNode? next = current.next;

            current.next = previous;
            previous = current;
            current = next;
        }

        while (node?.next is not null)
        {
            ListNode? next = node.next;
            node.next = previous;

            previous = previous?.next;
            node = node.next;

            if (node is null)
            {
                break;
            }

            node.next = next;
            node = node.next;
        }
    }

    [Fact]
    public void LC_Case_1()
    {
        ListNode source = ListNode.FromList([1, 2, 3, 4])!;
        ReorderList(source);

        Assert.Equal(ListNode.FromList([1, 4, 2, 3]), source, new ListNodeComparer()!);
    }

    [Fact]
    public void LC_Case_2()
    {
        ListNode source = ListNode.FromList([1, 2, 3, 4, 5])!;
        ReorderList(source);

        Assert.Equal(ListNode.FromList([1, 5, 2, 4, 3]), source, new ListNodeComparer()!);
    }

    [Fact]
    public void LC_Case_3()
    {
        ListNode source = ListNode.FromList([1, 2, 3, 4, 5, 6, 7, 8, 9, 0])!;
        ReorderList(source);

        Assert.Equal(ListNode.FromList([1, 0, 2, 9, 3, 8, 4, 7, 5, 6]), source, new ListNodeComparer()!);
    }
}