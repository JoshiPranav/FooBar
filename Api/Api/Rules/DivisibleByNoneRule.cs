using System.Threading.Tasks;

namespace Api.Rules
{
    public class DivisibleByNoneRule : DivisibilityRuleBase<DivisibleByNoneRule>
    {
        public override async Task<DivisibilityResult> ApplyRuleAsync(int number)
        {
            return new DivisibilityResult { IsHandled = true, Result = number.ToString() };
        }
    }
}
