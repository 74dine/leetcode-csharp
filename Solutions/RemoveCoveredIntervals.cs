namespace LeetcodeCSharp.Solutions;

public class RemoveCoveredIntervalsQ
{
    public int RemoveCoveredIntervals(int[][] intervals)
    {
        Array.Sort(intervals,
            (ints, ints1) => ints[0].Equals(ints1[0])
                ? ints1[1].CompareTo(ints[1])
                : ints[0].CompareTo(ints1[0]));

        int j = 0, count = 1;
        for (int i = 0; i < intervals.Length; i++)
        {
            if (intervals[j][0] <= intervals[i][0] && intervals[i][1] <= intervals[j][1])
            {
                continue;
            }

            j = i;
            count++;
        }

        return count;
    }

    [Fact]
    public void LC_Case_1()
    {
        Assert.Equal(2, RemoveCoveredIntervals([[1, 4], [3, 6], [2, 8]]));
    }

    [Fact]
    public void LC_Case_2()
    {
        Assert.Equal(1, RemoveCoveredIntervals([[1, 4], [2, 3]]));
    }

    [Fact]
    public void LC_Case_3()
    {
        Assert.Equal(1, RemoveCoveredIntervals([[1, 2], [1, 4], [3, 4]]));
    }
}