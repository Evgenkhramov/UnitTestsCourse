using Calculator;

namespace XUnitV3ForCalculatorTests;

[Collection("InsuranceTests")]
public class InsuranceTests(InsuranceCollectionFixture insuranceCollectionFixture)
{
    private readonly InsuranceCollectionFixture _insuranceCollectionFixture = insuranceCollectionFixture;
    [Fact]
    public void TestDiscountPercentage_GivenAge18_ReturnBetweenFiveAndTwenty()
    {
        var insurance = _insuranceCollectionFixture.Insureance;
        var result = insurance.DiscountPercentage(18);
        Assert.InRange(result, 5, 20);
    }

    [Fact]
    public void TestDiscountPercentage_GivenAgeBelow25_ReturnIs5()
    {
        var insurance = _insuranceCollectionFixture.Insureance;
        var result = insurance.DiscountPercentage(24);
        Assert.Equal(5, result);
    }

    [Fact]
    public void TestDiscountPercentage_GivenAge6_ThrowException()
    {
        var insurance = _insuranceCollectionFixture.Insureance;
        Assert.Throws<InvalidDataException>(() => insurance.DiscountPercentage(6));
    }

    [Fact]
    public void TestDiscountPercentage_GivenAge70_Return5()
    {
        var insurance = _insuranceCollectionFixture.Insureance;
        var result = insurance.DiscountPercentage(70);
        Assert.Equal(5, result);
    }

    [Fact]
    public void Customer_YearsLessThen5_ReturnLoyalCustomer()
    {
        var customer = CustomerFactory.GetInstance(3, 20);
        Assert.IsType<Customer>(customer);
    }

    [Fact]
    public void Customer_YearsGreaterThen5_ReturnLoyalCustomer()
    {
        var customer = CustomerFactory.GetInstance(6, 20);
        Assert.IsType<LoyalCustomer>(customer);
        Assert.IsNotType<Customer>(customer);
    }

    [Fact]
    public void Customer_YearsGreaterThen65_ReturnLoyalCustomerAndDiscountPlus10 ()
    {
        var customer = CustomerFactory.GetInstance(6, 65);
        Assert.IsType<LoyalCustomer>(customer);
        Assert.IsNotType<Customer>(customer);
        var discount = customer.Discount;
        Assert.Equal(15, discount);
    }

    [Fact]
    public void Customer_YearsGreaterThen45_ReturnLoyalCustomerAndDiscountPlus10()
    {
        var expected = 20;
        var customer = CustomerFactory.GetInstance(6, 45);
        var discount = customer.Discount;
        Assert.Equal(expected, discount);
    }
}
