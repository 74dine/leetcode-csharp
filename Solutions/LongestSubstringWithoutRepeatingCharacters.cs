namespace LeetcodeCSharp.Solutions;

public class LongestSubstringWithoutRepeatingCharacters
{
    public int LengthOfLongestSubstring(string s)
    {
        HashSet<char> distinct = new();
        int start = 0, end = 0, max = 0;

        for (; end < s.Length; end++)
        {
            while (distinct.Contains(s[end]))
            {
                distinct.Remove(s[start]);
                start++;
            }

            if (distinct.Add(s[end]) && distinct.Count > max)
            {
                max = distinct.Count;
            }
        }

        return max;
    }

    [Fact]
    public void LC_Case_1()
    {
        Assert.Equal(3, LengthOfLongestSubstring("abcabcbb"));
    }

    [Fact(DisplayName = "Does Handle All Same")]
    public void LC_Case_2()
    {
        Assert.Equal(1, LengthOfLongestSubstring("bbbbb"));
    }

    [Fact]
    public void LC_Case_3()
    {
        Assert.Equal(3, LengthOfLongestSubstring("pwwkew"));
    }

    [Fact]
    public void Does_Handle_All_Unique()
    {
        Assert.Equal(4, LengthOfLongestSubstring("abcd"));
    }

    [Fact]
    public void Does()
    {
        Assert.Equal(5, LengthOfLongestSubstring("qrsvbspk"));
        // bcdefa
    }
}