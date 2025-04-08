namespace XUnitV3ForCalculatorTests;

public static class CalculatorTestDataShare
{
    public static IEnumerable<object[]> AddTestData =>
        new List<object[]>
        {
            new object[] { 2, 3, 5 },
            new object[] { 3, -4, -1 },
            new object[] { 5, 5, 10 }
        };
}
