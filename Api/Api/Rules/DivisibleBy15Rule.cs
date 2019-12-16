using System.Threading.Tasks;

namespace Api.Rules
{
    public class DivisibleBy15Rule : DivisibilityRuleBase<DivisibleBy15Rule>
    {
        public override async Task<DivisibilityResult> ApplyRuleAsync(int number)
        {
            if (number % 15 == 0)
            {
                return new DivisibilityResult { IsHandled = true, Result = "FooBar" };
            }
            return new DivisibilityResult { IsHandled = false };
        }
    }
}
