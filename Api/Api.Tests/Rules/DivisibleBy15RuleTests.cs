using Xunit;
using Api.Rules;
using FluentAssertions;

namespace Api.Tests.Rules
{
    public class DivisibleBy15RuleTests
    {
        [Fact]
        public void ApplyRuleAsync_When_15_Returns_FooBar()
        {
            var divRule = new DivisibleBy15Rule();
            var result = divRule.ApplyRuleAsync(15).Result;
            result.Should().BeOfType<DivisibilityResult>();
            result.IsHandled.Should().Be(true);
            result.Result.Should().Be("FooBar");
        }

        [Fact]
        public void ApplyRuleAsync_When_Not_15_Returns_False()
        {
            var divRule = new DivisibleBy15Rule();
            var result = divRule.ApplyRuleAsync(5).Result;
            result.Should().BeOfType<DivisibilityResult>();
            result.IsHandled.Should().Be(false);
            result.Result.Should().BeNullOrEmpty();
        }
    }
}
