using Api.Rules;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IFooBarService
    {
        Task<FooBarResult> GetFooBarAsync(int number);
        Task<List<FooBarResult>> GetFooBarResultsAsync(int from, int to);
        Task<bool> ValidateAsync(FooBarResult fooBarResult);
    }
    public class FooBarService : IFooBarService
    {
        private readonly DivisibilityRuleBase<DivisibleBy15Rule> _divisibleBy15Rule;
        private readonly DivisibilityRuleBase<DivisibleBy5Rule> _divisibleBy5Rule;
        private readonly DivisibilityRuleBase<DivisibleBy3Rule> _divisibleBy3Rule;
        private readonly DivisibilityRuleBase<DivisibleByNoneRule> _divisibleByNoneRule;

        public FooBarService(DivisibilityRuleBase<DivisibleBy15Rule> divisibleBy15Rule
            , DivisibilityRuleBase<DivisibleBy5Rule> divisibleBy5Rule
            , DivisibilityRuleBase<DivisibleBy3Rule> divisibleBy3Rule
            , DivisibilityRuleBase<DivisibleByNoneRule> divisibleByNoneRule)
        {
            _divisibleBy15Rule = divisibleBy15Rule;
            _divisibleBy5Rule = divisibleBy5Rule;
            _divisibleBy3Rule = divisibleBy3Rule;
            _divisibleByNoneRule = divisibleByNoneRule;

            _divisibleBy15Rule
                .SetNext(_divisibleBy5Rule)
                .SetNext(_divisibleBy3Rule)
                .SetNext(_divisibleByNoneRule);
        }

        public async Task<FooBarResult> GetFooBarAsync(int number)
        {
            var result = await _divisibleBy15Rule.HandleAsync(number);
            return new FooBarResult { Number = number, Result = result };
        }

        public async Task<List<FooBarResult>> GetFooBarResultsAsync(int from, int to)
        {
            var results = new List<FooBarResult>();
            for (var i = from; i <= to; i++)
            {
                var result = await _divisibleBy15Rule.HandleAsync(i);
                results.Add(new FooBarResult { Number = i, Result = result });
            }
            return results;
        }

        public async Task<bool> ValidateAsync(FooBarResult fooBarResult)
        {
            var result = await _divisibleBy15Rule.HandleAsync(fooBarResult.Number);
            return result == fooBarResult.Result;
        }
    }
}
