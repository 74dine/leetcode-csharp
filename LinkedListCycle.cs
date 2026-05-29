using LeetcodeCSharp.Models;

namespace LeetcodeCSharp;

public class LinkedListCycle
{
    public bool HasCycle(ListNode head)
    {
        var distinctNodes = new HashSet<ListNode>();

        ListNode? current = head;
        while (current != null)
        {
            if (!distinctNodes.Add(current))
            {
                return true;
            }

            current = current.next;
        }

        return false;
    }

    [Fact]
    public void LC_Case_1()
    {
        var cycleStart = new ListNode(2);
        Assert.True(HasCycle(new ListNode(3)
            .next = cycleStart
            .next = new ListNode(0)
            .next = new ListNode(-4)
            .next = cycleStart));
    }
}