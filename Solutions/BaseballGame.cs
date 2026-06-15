namespace LeetcodeCSharp.Solutions;

public class BaseballGame
{
    private static int CalPoints(string[] operations)
    {
        var history = new List<int>(operations.Length);

        foreach (var op in operations)
        {
            switch (op)
            {
                case "+":
                    {
                        history.Add(history[^2] + history[^1]);
                        break;
                    }
                case "D":
                    {
                        history.Add(history[^1] * 2);
                        break;
                    }
                case "C":
                    {
                        history.RemoveAt(history.Count - 1);
                        break;
                    }
                default:
                    {
                        history.Add(int.Parse(op));
                        break;
                    }
            }
        }

        return history.Sum();
    }

    [Fact]
    public void LC_Case_1()
    {
        Assert.Equal(30, CalPoints(["5", "2", "C", "D", "+"]));
    }

    [Fact]
    public void LC_Case_2()
    {
        Assert.Equal(27, CalPoints(["5", "-2", "4", "C", "D", "9", "+", "+"]));
    }

    [Fact]
    public void LC_Case_3()
    {
        Assert.Equal(0, CalPoints(["1", "C"]));
    }

    [Fact]
    public void Does_Sum()
    {
        Assert.Equal(6, CalPoints(["1", "2", "3"]));
    }

    [Fact]
    public void Does_Add_Sum_Of_Last_Two()
    {
        Assert.Equal(11, CalPoints(["1", "2", "3", "+"]));
    }

    [Fact]
    public void Dess_Add_Double_Of_Last()
    {
        Assert.Equal(12, CalPoints(["1", "2", "3", "D"]));
    }

    [Fact]
    public void Does_Remove_Last()
    {
        Assert.Equal(3, CalPoints(["1", "2", "3", "C"]));
    }

    [Fact]
    public void Does_Clear_History()
    {
        Assert.Equal(0, CalPoints(["1", "2", "3", "C", "C", "C"]));
    }
}