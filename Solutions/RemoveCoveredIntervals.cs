using Xunit.Abstractions;

namespace LeetcodeCSharp.Solutions;

public class RemoveCoveredIntervalsQ(ITestOutputHelper _out)
{
    public int RemoveCoveredIntervals(int[][] intervals)
    {
        return intervals
            .OrderBy(x => x[0])
            .ThenByDescending(x => x[1])
            .Aggregate(new List<int[]>(), (agg, cur) =>
            {
                if (agg.Count == 0 || agg.Last()[0] > cur[0] || cur[1] > agg.Last()[1])
                {
                    agg.Add(cur);
                }

                return agg;
            }).Count;
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