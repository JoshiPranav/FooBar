using System.Threading.Tasks;

namespace Api.Rules
{
    public class DivisibleBy3Rule : DivisibilityRuleBase<DivisibleBy3Rule>
    {
        public override async Task<DivisibilityResult> ApplyRuleAsync(int number)
        {
            if (number % 3 == 0)
            {
                return new DivisibilityResult { IsHandled = true, Result = "Foo" };
            }
            return new DivisibilityResult { IsHandled = false };
        }
    }
}
