namespace LeetcodeCSharp.Solutions;

public class TwoSumII_InputArrayIsSorted
{
    private static int[] TwoSum(int[] numbers, int target)
    {
        int i = 0, j = numbers.Length - 1;

        while (i < j)
        {
            if (numbers[i] + numbers[j] == target)
            {
                return [i + 1, j + 1];
            }

            if (numbers[i] + numbers[j] < target)
            {
                i++;
            }
            else if (numbers[i] + numbers[j] > target)
            {
                j--;
            }
        }

        throw new ArgumentException("Provided input was invalid.");
    }


    [Fact]
    public void LC_Case_One()
    {
        int[] input = [2, 7, 11, 15];
        int[] expect = [1, 2];

        Assert.Equal(expect, TwoSum(input, 9));
    }

    [Fact]
    public void LC_Case_Two()
    {
        int[] input = [2, 3, 4];
        int[] expect = [1, 3];

        Assert.Equal(expect, TwoSum(input, 6));
    }

    [Fact]
    public void LC_Case_Three()
    {
        int[] input = [-1, 0];
        int[] expect = [1, 2];

        Assert.Equal(expect, TwoSum(input, -1));
    }

    [Fact]
    public void Does_Calculate_Positive()
    {
        int[] input = [1, 2, 3, 5, 6];
        int[] expect = [2, 3];

        Assert.Equal(expect, TwoSum(input, 5));
    }

    [Fact]
    public void Does_Calculate_Negative()
    {
        int[] input = [-15, -11, -7, -2];
        int[] expect = [3, 4];

        Assert.Equal(expect, TwoSum(input, -9));
    }
}