using Api.Controllers;
using Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests.Controllers
{
    
    public class FooBarControllerTests
    {
        private IFooBarService mockService = Substitute.For<IFooBarService>();
        private ILogger<FooBarController> mockLogger = new NullLogger<FooBarController>();

        [Fact]
        public void GetAsync_When_GetsData_Then_Ok()
        {
            mockService.GetFooBarAsync(Arg.Any<int>()).Returns(Task.Run(() => new FooBarResult() { Number = 1, Result = "1" }));
            var controller = new FooBarController(mockLogger, mockService);
            var result = controller.Get(1).Result;
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().BeOfType<FooBarResult>();
        }

        [Fact]
        public void GetAsync_When_NullData_Then_NotFound()
        {
            FooBarResult nullResult = null;
            mockService.GetFooBarAsync(Arg.Any<int>()).Returns(Task.Run(() => nullResult));
            var controller = new FooBarController(mockLogger, mockService);
            var result = controller.Get(1).Result;
            var notFoundResult = result.Should().BeOfType<NotFoundResult>().Subject;
        }

        [Fact]
        public void GetAsync_When_Failed_Then_BadRequest()
        {
            mockService.GetFooBarAsync(Arg.Any<int>()).Throws(new Exception());
            var controller = new FooBarController(mockLogger, mockService);
            var result = controller.Get(1).Result;
            var badReqResult = result.Should().BeOfType<BadRequestObjectResult>().Subject;
        }

        [Fact]
        public void GetAllAsync_When_GetsData_Then_Ok()
        {
            var result = new List<FooBarResult>
            {
                new FooBarResult { Number = 1, Result = "1" }
            };
            mockService.GetFooBarResultsAsync(Arg.Any<int>(), Arg.Any<int>()).Returns(Task.Run(() => result));
            var controller = new FooBarController(mockLogger, mockService);
            var results = controller.GetAll(1,3).Result;
            var okResult = results.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().BeOfType<List<FooBarResult>>();
        }

        [Fact]
        public void GetAllAsync_When_NullData_Then_NotFound()
        {
            List<FooBarResult> nullResult = null;
            mockService.GetFooBarResultsAsync(Arg.Any<int>(), Arg.Any<int>()).Returns(Task.Run(() => nullResult));
            var controller = new FooBarController(mockLogger, mockService);
            var result = controller.GetAll(1,3).Result;
            var notFoundResult = result.Should().BeOfType<NotFoundResult>().Subject;
        }

        [Fact]
        public void GetAllAsync_When_Failed_Then_BadRequest()
        {
            mockService.GetFooBarResultsAsync(Arg.Any<int>(), Arg.Any<int>()).Throws(new Exception());
            var controller = new FooBarController(mockLogger, mockService);
            var result = controller.GetAll(1,1).Result;
            var badReqResult = result.Should().BeOfType<BadRequestObjectResult>().Subject;
        }

        [Fact]
        public void ValidateAsync_When_ReturnsTrue_Then_Ok()
        {
            var result = new FooBarResult { Number = 1, Result = "1" };
            mockService.ValidateAsync(Arg.Any<FooBarResult>()).Returns(Task.Run(() => true));
            var controller = new FooBarController(mockLogger, mockService);
            var results = controller.Validate(result).Result;
            var okResult = results.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().BeOfType<bool>();
        }

        [Fact]
        public void ValidateAsync_When_NullData_Then_BadRequest()
        {
            mockService.ValidateAsync(Arg.Any<FooBarResult>()).Returns(Task.Run(() => true));
            var controller = new FooBarController(mockLogger, mockService);
            var result = controller.Validate(null).Result;
            var badRequestResult = result.Should().BeOfType<BadRequestObjectResult>().Subject;
        }
    }
}
