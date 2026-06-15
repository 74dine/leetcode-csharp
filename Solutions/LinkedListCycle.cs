using LeetcodeCSharp.Models;

namespace LeetcodeCSharp.Solutions;

public class LinkedListCycle
{
    public bool HasCycle(ListNode? head)
    {
        if (head is null) return false;

        var cursor = head;
        var fast = head.next;

        while (cursor is not null)
        {
            if (cursor == fast)
            {
                return true;
            }

            cursor = cursor.next;
            fast = fast?.next?.next;
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

    [Fact]
    public void LC_Case_2()
    {
        var cycleStart = new ListNode(1);

        Assert.True(HasCycle(cycleStart.next = new ListNode(2).next = cycleStart));
    }

    [Fact]
    public void LC_Case_3()
    {
        Assert.False(HasCycle(new ListNode(1)));
    }
}