using Xunit;
using Api.Rules;
using FluentAssertions;

namespace Api.Tests.Rules
{
    public class DivisibleBy5RuleTests
    {
        [Fact]
        public void ApplyRuleAsync_When_5_Returns_Bar()
        {
            var divRule = new DivisibleBy5Rule();
            var result = divRule.ApplyRuleAsync(5).Result;
            result.Should().BeOfType<DivisibilityResult>();
            result.IsHandled.Should().Be(true);
            result.Result.Should().Be("Bar");
        }

        [Fact]
        public void ApplyRuleAsync_When_Not_15_Returns_False()
        {
            var divRule = new DivisibleBy5Rule();
            var result = divRule.ApplyRuleAsync(16).Result;
            result.Should().BeOfType<DivisibilityResult>();
            result.IsHandled.Should().Be(false);
            result.Result.Should().BeNullOrEmpty();
        }
    }
}
