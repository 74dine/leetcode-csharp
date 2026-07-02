namespace LeetcodeCSharp.Solutions;

public class LongestSubstringWithoutRepeatingCharacters
{
    public int LengthOfLongestSubstring(string s)
    {
        Span<uint> posHistory = stackalloc uint[char.MaxValue + 1];
        uint start = 0, max = 0;

        for (uint i = 0; i < s.Length; i++)
        {
            if (posHistory[s[(int)i]] > start)
            {
                start = posHistory[s[(int)i]];
            }

            posHistory[s[(int)i]] = i + 1;

            uint l = i - start + 1;
            max = Math.Max(max, l);
        }

        return (int)max;
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
    public void LC_Case_4()
    {
        Assert.Equal(5, LengthOfLongestSubstring("qrsvbspk"));
    }

    [Fact]
    public void Does_Handle_All_Unique()
    {
        Assert.Equal(4, LengthOfLongestSubstring("abcd"));
    }
}