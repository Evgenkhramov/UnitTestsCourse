namespace XUnitV3ForCalculatorTests;

[Collection("InsuranceTests")]
public class InsuranceDetailsTest(InsuranceCollectionFixture insuranceCollectionFixture)
{
    private readonly InsuranceCollectionFixture _insuranceCollectionFixture = insuranceCollectionFixture;

    [Fact]
    public void Insurance_interestRate()
    {
        // Arrange
        var insurance = _insuranceCollectionFixture.Insureance;
        // Act
        var interestRate = insurance.InterestRate;
        // Assert
        Assert.Equal(10, interestRate);
    }
}
