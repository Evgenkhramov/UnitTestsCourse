using Calculator;

namespace XUnitV3ForCalculatorTests;

public class CalculatorTest
{
    [Fact]
    public void TestAdd_Given2And3_Return5()
    {
        var calcaulator = new SimpleCalculator();

        var result = calcaulator.Add(2, 3);

        Assert.Equal(5, result);
    }

    [Fact]
    public void TestAddDeciaml_GivenTwoDeciamls_ReturnCorrectDeciaml()
    {
        var calcaulator = new SimpleCalculator();

        var result = calcaulator.Add(2.3m, 3.3m);

        Assert.Equal(5.6m, result);
    }
}
