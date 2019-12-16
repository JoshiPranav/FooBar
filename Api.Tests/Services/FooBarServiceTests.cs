using Api.Rules;
using Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Api.Tests.Services
{
    public class FooBarServiceTests : IDisposable
    {
        private DivisibilityRuleBase<DivisibleBy15Rule> _divisibleBy15Rule;
        private DivisibilityRuleBase<DivisibleBy5Rule> _divisibleBy5Rule;
        private DivisibilityRuleBase<DivisibleBy3Rule> _divisibleBy3Rule;
        private DivisibilityRuleBase<DivisibleByNoneRule> _divisibleByNoneRule;
        private FooBarService _service;

        public FooBarServiceTests()
        {
            _divisibleBy15Rule = new DivisibleBy15Rule();
            _divisibleBy3Rule = new DivisibleBy3Rule();
            _divisibleBy5Rule = new DivisibleBy5Rule();
            _divisibleByNoneRule = new DivisibleByNoneRule();
            _service = new FooBarService(_divisibleBy15Rule, _divisibleBy5Rule, _divisibleBy3Rule, _divisibleByNoneRule);
        }
        public void Dispose()
        {
            _divisibleBy15Rule = null;
            _divisibleBy3Rule = null;
            _divisibleBy5Rule = null;
            _divisibleByNoneRule = null;
            _service = null;
        }

        [Fact]
        public void GetFooBarAsync_When_1_Returns_1()
        {
            var result = _service.GetFooBarAsync(1).Result;
            result.Should().BeOfType<FooBarResult>();
            result.Number.Should().Be(1);
            result.Result.Should().Be("1");
        }

        [Fact]
        public void GetFooBarAsync_When_15_Returns_FooBar()
        {
            var result = _service.GetFooBarAsync(15).Result;
            result.Should().BeOfType<FooBarResult>();
            result.Number.Should().Be(15);
            result.Result.Should().Be("FooBar");
        }

        [Fact]
        public void GetFooBarAsync_When_5_Returns_Bar()
        {
            var result = _service.GetFooBarAsync(5).Result;
            result.Should().BeOfType<FooBarResult>();
            result.Number.Should().Be(5);
            result.Result.Should().Be("Bar");
        }

        [Fact]
        public void GetFooBarAsync_When_3_Returns_Foo()
        {
            var result = _service.GetFooBarAsync(3).Result;
            result.Should().BeOfType<FooBarResult>();
            result.Number.Should().Be(3);
            result.Result.Should().Be("Foo");
        }

        [Fact]
        public void GetFooBarResultsAsync_Returns_Correct_Results()
        {
            var result = _service.GetFooBarResultsAsync(0, 16).Result;
            result.Should().BeOfType<List<FooBarResult>>();
            result.First().Number.Should().Be(0);
            result.First().Result.Should().Be("FooBar");
            result.Last().Number.Should().Be(16);
            result.Last().Result.Should().Be("16");
            result.Where(x => x.Number == 10).First().Result.Should().Be("Bar");
            result.Where(x => x.Number == 9).First().Result.Should().Be("Foo");
            result.Where(x => x.Number == 15).First().Result.Should().Be("FooBar");
        }

        [Fact]
        public void ValidateAsync_When_Correct_Returns_True()
        {
            var result = _service.ValidateAsync(new FooBarResult { Number = 1, Result = "1" }).Result;
            result.Should().Be(true);
        }

        [Fact]
        public void ValidateAsync_When_InCorrect_Returns_False()
        {
            var result = _service.ValidateAsync(new FooBarResult { Number = 5, Result = "5" }).Result;
            result.Should().Be(true);
        }

        [Fact]
        public void ValidateAsync_When_15_FooBar_Returns_True()
        {
            var result = _service.ValidateAsync(new FooBarResult { Number = 15, Result = "FooBar" }).Result;
            result.Should().Be(true);
        }

        [Fact]
        public void ValidateAsync_When_5_Bar_Returns_True()
        {
            var result = _service.ValidateAsync(new FooBarResult { Number = 5, Result = "Bar" }).Result;
            result.Should().Be(true);
        }

        [Fact]
        public void ValidateAsync_When_3_Foo_Returns_True()
        {
            var result = _service.ValidateAsync(new FooBarResult { Number = 3, Result = "Foo" }).Result;
            result.Should().Be(true);
        }
    }
}
