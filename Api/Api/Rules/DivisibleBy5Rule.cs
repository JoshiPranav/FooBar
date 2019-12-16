using System.Threading.Tasks;

namespace Api.Rules
{
    public class DivisibleBy5Rule : DivisibilityRuleBase<DivisibleBy5Rule>
    {
        public override async Task<DivisibilityResult> ApplyRuleAsync(int number)
        {
            if (number % 5 == 0)
            {
                return new DivisibilityResult { IsHandled = true, Result = "Bar" };
            }
            return new DivisibilityResult { IsHandled = false };
        }
    }
}
