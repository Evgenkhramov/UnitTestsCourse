namespace Calculator;

public class Insurance
{
    public int DiscountPercentage(int age)
    {
        return age switch
        {
            >= 65 => 5,
            >= 45 => 10,
            >= 25 => 20,
            >= 18 => 5,
            _ => throw new InvalidDataException(),
        };
    }
}

public class Customer(Insurance insurance, int age)
{
    public virtual int Discount => insurance.DiscountPercentage(age);
}

public class LoyalCustomer(Insurance insurance, int age) : Customer(insurance, age)
{
    private readonly Insurance _insurance = insurance;
    public override int Discount => _insurance.DiscountPercentage(age) + 10;
}


public static class CustomerFactory
{
    public static Customer GetInstance(int yearsInCompany, int age)
    {
        var insurance = new Insurance();
        if (yearsInCompany >= 5)
            return new LoyalCustomer(insurance, age);
       
        return new Customer(insurance, age);
    }
}
