namespace LeetcodeCSharp.Solutions;

public class NumberOfStringsThatAppearAsSubstringsInWord
{
    public int NumOfStrings(string[] patterns, string word)
    {
        return patterns.Count(word.Contains);
    }

    [Fact]
    public void LC_Case_1()
    {
        Assert.Equal(3, NumOfStrings(["a", "abc", "bc", "d"], "abc"));
    }

    [Fact]
    public void LC_Case_2()
    {
        Assert.Equal(2, NumOfStrings(["a", "b", "c"], "aaaaabbbbb"));
    }

    [Fact]
    public void LC_Case_3()
    {
        Assert.Equal(3, NumOfStrings(["a", "a", "a"], "ab"));
    }
}