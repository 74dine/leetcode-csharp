namespace LeetcodeCSharp;

// ReSharper disable once ClassNeverInstantiated.Global
public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public int val = val;
    public TreeNode? left = left;
    public TreeNode? right = right;
}

public class Solution
{
    public TreeNode CreateBinaryTree(int[][] descriptions)
    {
        var nodes = new Dictionary<int, TreeNode>(descriptions.Length);
        var children = new HashSet<int>(descriptions.Length - 1);

        foreach (var node in descriptions)
        {
            if (!nodes.TryGetValue(node[0], out var parent))
            {
                nodes[node[0]] = parent = new TreeNode(node[0]);
            }

            if (!nodes.TryGetValue(node[1], out var child))
            {
                nodes[node[1]] = child = new TreeNode(node[1]);
            }

            if (node[2] == 1)
            {
                parent.left = child;
            }
            else
            {
                parent.right = child;
            }

            children.Add(child.val);
        }

        foreach ((int val, TreeNode node) in nodes)
        {
            if (!children.Contains(val))
            {
                return node;
            }
        }

        throw new InvalidOperationException("Unable to create binary tree.");
    }

    [Fact]
    public void LC_Case_1()
    {
        var expectedRoot = new TreeNode(50, new TreeNode(20), new TreeNode(80));

        expectedRoot.left!.left = new TreeNode(15);
        expectedRoot.left!.right = new TreeNode(17);

        expectedRoot.right!.left = new TreeNode(19);

        Assert.Equivalent(expectedRoot,
            CreateBinaryTree([[20, 15, 1], [20, 17, 0], [50, 20, 1], [50, 80, 0], [80, 19, 1]]));
    }

    [Fact]
    public void LC_Case_2()
    {
        var expectedRoot = new TreeNode(1, new TreeNode(2));

        expectedRoot.left!.right = new TreeNode(3, new TreeNode(4));

        Assert.Equivalent(expectedRoot, CreateBinaryTree([[1, 2, 1], [2, 3, 0], [3, 4, 1]]));
    }

    [Fact]
    public void LC_Case_3()
    {
        var expectedRoot = new TreeNode(38, null, new TreeNode(82));

        expectedRoot.right!.right = new TreeNode(85, null,
            new TreeNode(74, null, new TreeNode(13, null, new TreeNode(39, null, new TreeNode(70)))));

        Assert.Equivalent(expectedRoot,
            CreateBinaryTree([[85, 74, 0], [38, 82, 0], [39, 70, 0], [82, 85, 0], [74, 13, 0], [13, 39, 0]]));
    }
}