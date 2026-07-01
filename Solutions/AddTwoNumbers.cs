using LeetcodeCSharp.Models;

using Xunit.Abstractions;

namespace LeetcodeCSharp.Solutions;

public class AddTwoNumbersQ(ITestOutputHelper _testOutputHelper)
{

    public ListNode AddTwoNumbers(ListNode? n1_cursor, ListNode? n2_cursor)
    {
        var result = new ListNode();
        var res_node = result;

        var carry = false;
        while (n1_cursor is not null || n2_cursor is not null)
        {
            var sum = (n1_cursor?.val ?? 0) + (n2_cursor?.val ?? 0) + (carry ? 1 : 0);
            _testOutputHelper.WriteLine($"n1: {n1_cursor?.val} n2: {n2_cursor?.val} Sum: {sum} Carry: {carry}");

            carry = sum > 9;

            var node = new ListNode(sum % 10);

            res_node.next = node;
            res_node = res_node.next;

            n1_cursor = n1_cursor?.next;
            n2_cursor = n2_cursor?.next;
        }

        if (carry)
        {
            res_node.next = new ListNode(1);
        }

        _testOutputHelper.WriteLine($"result: {result.next}");

        return result.next!;
    }

    [Fact]
    public void LC_Case_1()
    {
        var numA = ListNode.FromList([2, 4, 3]);
        var numB = ListNode.FromList([5, 6, 4]);

        Assert.Equal(ListNode.FromList([7, 0, 8]), AddTwoNumbers(numA!, numB!), new ListNodeComparer()!);
    }

    [Fact]
    public void LC_Case_2()
    {
        var numA = ListNode.FromList([0])!;
        var numB = ListNode.FromList([0])!;

        Assert.Equivalent(numA, AddTwoNumbers(numA, numB));
    }

    [Fact]
    public void LC_Case_3()
    {
        var numA = ListNode.FromList([9, 9, 9, 9, 9, 9, 9])!;
        var numB = ListNode.FromList([9, 9, 9, 9])!;

        Assert.Equal(ListNode.FromList([8, 9, 9, 9, 0, 0, 0, 1]), AddTwoNumbers(numA, numB), new ListNodeComparer()!);
    }

    [Fact]
    public void Does_Handle_Upper_Constraint()
    {
        var numA = ListNode.FromList([
            9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9,
            9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9,
            9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9
        ])!;

        var res = ListNode.FromList([
            8, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9,
            9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9,
            9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 1
        ])!;

        Assert.Equal(res, AddTwoNumbers(numA, numA), new ListNodeComparer());
    }
}