using Xunit;
using Api.Rules;
using FluentAssertions;

namespace Api.Tests.Rules
{
    public class DivisibleByNoneRuleTests
    {
        [Fact]
        public void ApplyRuleAsync_Returns_Number()
        {
            var divRule = new DivisibleByNoneRule();
            var result = divRule.ApplyRuleAsync(2).Result;
            result.Should().BeOfType<DivisibilityResult>();
            result.IsHandled.Should().Be(true);
            result.Result.Should().Be("2");
        }
    }
}
