using Calculator;

namespace XUnitV3ForCalculatorTests;

public class CalculatorFixture
{
    public SimpleCalculator Calculator => new();
}

public class CalculatorTest(ITestOutputHelper testHelper, CalculatorFixture calculatorFixture) : IClassFixture<CalculatorFixture>
{
    private readonly ITestOutputHelper _testOutputHelper = testHelper;
    private readonly CalculatorFixture _calculatorFixture = calculatorFixture;

    [Fact, Trait("Category", "Calculator")]
    public void TestAdd_Given2And3_Return5()
    {
        _testOutputHelper.WriteLine("Add write line TestAdd_Given2And3_Return5");
 
        var calculator = _calculatorFixture.Calculator;
        var result = calculator.Add(2, 3);

        Assert.Equal(5, result);
    }

    [Fact, Trait("Category", "Calculator")]
    public void TestAddDecimal_GivenTwoDecimals_ReturnCorrectDecimal()
    {
        var calculator = _calculatorFixture.Calculator;
        var result = calculator.Add(2.3m, 3.3m);

        Assert.Equal(5.6m, result);
    }

    [Fact, Trait("Category", "Calculator")]
    public void TestSubtract_GivenFiveMinusThree_ReturnTwo()
    {
        var calculator = _calculatorFixture.Calculator;

        var result = calculator.Subtract(5, 3);

        Assert.Equal(2, result);
    }

    [Fact, Trait("Category", "Calculator")]
    public void TestMultiply_GivenFiveMultiplyTwo_ReturnTen()
    {
        var calculator = _calculatorFixture.Calculator;

        var result = calculator.Multiply(5, 2);

        Assert.Equal(10, result);
    }

    [Fact, Trait("Category", "Calculator")]
    public void TestDivide_GivenTenDivideTwo_ReturnFive()
    {
        var calculator = _calculatorFixture.Calculator;

        var result = calculator.Divide(10, 2);

        Assert.Equal(5, result);
    }

    [Fact, Trait("Category", "Calculator")]
    public void TestDivide_GivenTenDivideZero_ThrowException()
    {
        var calculator = _calculatorFixture.Calculator;

        Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
    }

    [Fact, Trait("Category", "Fibo")]
    public void GetFibonacci_DoesNotIncludeZero()
    {
        var calculator = _calculatorFixture.Calculator;
        var result = calculator.GetFibonacci(10);
        Assert.DoesNotContain(0, result);
    }

    [Fact, Trait("Category", "Fibo")]
    public void GetFibonacci_DoesNotIncludeFour()
    {
        var calculator = _calculatorFixture.Calculator;
        var result = calculator.GetFibonacci(10);
        Assert.DoesNotContain(4, result);
    }

    [Fact, Trait("Category", "Fibo")]
    public void GetFibonacci_IncludeFive()
    {
        var calculator = _calculatorFixture.Calculator;
        var result = calculator.GetFibonacci(10);
        Assert.Contains(5, result);
    }

    [Fact, Trait("Category", "Fibo")]
    public void GetFibonacci_FirstFiveMembers_AreCorrect()
    {
        var calculator = _calculatorFixture.Calculator;
        var result = calculator.GetFibonacci(5);
        var expectFibonacci = new List<int> { 1, 1, 2, 3, 5 };
        Assert.Equal(expectFibonacci, result);
    }
}
