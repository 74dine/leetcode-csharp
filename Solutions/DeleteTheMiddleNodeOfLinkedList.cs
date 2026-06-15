using LeetcodeCSharp.Models;

using Xunit.Abstractions;

namespace LeetcodeCSharp.Solutions;

public class DeleteTheMiddleNodeOfLinkedList
{
    private readonly ITestOutputHelper _testOutputHelper;

    public DeleteTheMiddleNodeOfLinkedList(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    public ListNode DeleteMiddle(ListNode head)
    {
        if (head is null) return head;
        if (head.next == null) return null;

        var slow = head;
        var fast = head.next?.next;

        while (fast?.next is not null)
        {
            slow = slow?.next;
            fast = fast.next.next;
        }

        slow.next = slow.next?.next;

        return head!;
    }

    /* invalid tests */
    [Fact]
    public void LC_Case_1()
    {
        var a = new ListNode(1)
            .next = new ListNode(3)
            .next = new ListNode(4)
            .next = new ListNode(1)
            .next = new ListNode(2)
            .next = new ListNode(6);
        var b = new ListNode(1)
            .next = new ListNode(3)
            .next = new ListNode(4)
            .next = new ListNode(7)
            .next = new ListNode(1)
            .next = new ListNode(2)
            .next = new ListNode(6);

        _testOutputHelper.WriteLine(a + "\n" + b);

        Assert.Equivalent(a, DeleteMiddle(b));
    }

    [Fact]
    public void LC_Case_2()
    {
        Assert.Equivalent(
            new ListNode(1)
                .next = new ListNode(2)
                .next = new ListNode(4)
            ,
            new ListNode(1)
                .next = new ListNode(2)
                .next = new ListNode(3)
                .next = new ListNode(4)
        );
    }

    [Fact]
    public void LC_Case_3()
    {
        Assert.Equivalent(
            new ListNode(2)
            ,
            new ListNode(2)
                .next = new ListNode(1)
        );
    }

    [Fact]
    public void Does_handle_single_node()
    {
        Assert.Equivalent(null, DeleteMiddle( new ListNode(1)));
    }
}