using Calculator;

namespace XUnitV3ForCalculatorTests;

public class NamesTest
{
    [Fact]
    public void TestFullName_GivenFirstAndLastName_ReturnFullName()
    {
        var names = new Names();
        var result = names.FullName("John", "Doe");
        Assert.Equal("john Doe", result, ignoreCase: true);
    }

    [Fact]
    public void TestFullName_GivenFirstAndLastName_MatchesRegex()
    {
        var names = new Names();
        var result = names.FullName("John", "Doe");
        Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", result);
    }

    [Fact]
    public void TestFullName_GivenFirstAndLastName_FirstNameExists()
    {
        var names = new Names();
        var result = names.FullName("John", "Doe");
        Assert.Contains("john", result, StringComparison.CurrentCultureIgnoreCase);
    } 
    
    [Fact]
    public void TestFullName_GivenFirstAndLastName_BeginsWithFirstName()
    {
        var names = new Names();
        var result = names.FullName("John", "Doe");
        Assert.StartsWith("John", result);
    }

    [Fact]
    public void TestFullName_CreateClassNames_NickNameIsCorrect()
    {
        var names = new Names();
        Assert.Null(names.NickName);

        names.FullName("John", "Doe");
        Assert.NotNull(names.NickName);
        Assert.Equal("J+D", names.NickName);
    }
}
