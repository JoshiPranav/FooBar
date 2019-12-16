using System.Threading.Tasks;

namespace Api.Rules
{
    public interface IDivisibilityRule
    {
        IDivisibilityRule SetNext(IDivisibilityRule divisibilityRule);
        Task<string> HandleAsync(int number);
    }

    public abstract class DivisibilityRuleBase<T> : IDivisibilityRule where T : class
    {
        private IDivisibilityRule _nextDivisibilityRule;
        public abstract Task<DivisibilityResult> ApplyRuleAsync(int number);
        public async Task<string> HandleAsync(int number)
        {
            var result = await ApplyRuleAsync(number);
            if (result != null && result.IsHandled)
            {
                return result.Result;
            }
            if (_nextDivisibilityRule == null)
            {
                return string.Empty;
            }
            else
            {
                return await _nextDivisibilityRule.HandleAsync(number);
            }
        }

        public IDivisibilityRule SetNext(IDivisibilityRule divisibilityRule)
        {
            _nextDivisibilityRule = divisibilityRule;
            return divisibilityRule; //return for function chaining
        }
    }
}
