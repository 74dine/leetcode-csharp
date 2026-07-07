namespace LeetcodeCSharp.Solutions;

public class ConcatenateNonZeroDigitsAndMultiplyBySumI
{
    public long SumAndMultiply(int n)
    {
        int d = 0, s = 0, l = 0;
        while (n > 0)
        {
            int p = n % 10;
            if (p > 0)
            {
                d = d + (p * (int)Math.Pow(10, l));
                s += p;
                l++;
            }

            n /= 10;
        }

        return d * (long)s;
    }

    [Fact]
    public void LC_Case_1()
    {
        Assert.Equal(12340, SumAndMultiply(10203004));
    }

    [Fact]
    public void LC_Case_2()
    {
        Assert.Equal(1, SumAndMultiply(1000));
    }

    [Fact]
    public void Does_Handle_Max_N()
    {
        Assert.Equal(1, SumAndMultiply(1000));
    }

    [Fact]
    public void Does_Handle_Min_N()
    {
        Assert.Equal(0, SumAndMultiply(0));
    }

    [Fact]
    public void Does_Handle_Long_Result()
    {
        Assert.Equal(2618545120, SumAndMultiply(65463628));
    }

    [Fact]
    public void Does_Handle_Max_Result()
    {
        Assert.Equal(80999999919, SumAndMultiply(999999999));
    }
}