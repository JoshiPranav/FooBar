using Xunit;
using Api.Rules;
using FluentAssertions;

namespace Api.Tests.Rules
{
    public class DivisibleBy3RuleTests
    {
        [Fact]
        public void ApplyRuleAsync_When_3_Returns_Foo()
        {
            var divRule = new DivisibleBy3Rule();
            var result = divRule.ApplyRuleAsync(3).Result;
            result.Should().BeOfType<DivisibilityResult>();
            result.IsHandled.Should().Be(true);
            result.Result.Should().Be("Foo");
        }

        [Fact]
        public void ApplyRuleAsync_When_Not_15_Returns_False()
        {
            var divRule = new DivisibleBy3Rule();
            var result = divRule.ApplyRuleAsync(15).Result;
            result.Should().BeOfType<DivisibilityResult>();
            result.IsHandled.Should().Be(false);
            result.Result.Should().BeNullOrEmpty();
        }
    }
}
