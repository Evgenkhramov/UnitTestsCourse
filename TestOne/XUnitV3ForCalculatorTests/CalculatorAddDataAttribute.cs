using System.Reflection;
using Xunit.Sdk;
using Xunit.v3;

namespace XUnitV3ForCalculatorTests;

public class CalculatorAddDataAttribute : DataAttribute
{
    public override ValueTask<IReadOnlyCollection<ITheoryDataRow>> GetData(MethodInfo testMethod, DisposalTracker disposalTracker)
    {
        return new ValueTask<IReadOnlyCollection<ITheoryDataRow>>(
            [
                new TheoryDataRow(2, 3, 5),
                new TheoryDataRow(3, -4, -1),
                new TheoryDataRow(5, 5, 10)
            ]
        );
    }

    public override bool SupportsDiscoveryEnumeration()
    {
        return true;
    }
}
