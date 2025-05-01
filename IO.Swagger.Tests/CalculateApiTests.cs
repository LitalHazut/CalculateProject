using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using IO.Swagger.Controllers;
using IO.Swagger.Models;

namespace IO.Swagger.Tests
{
    [TestFixture]
    public class CalculateApiTests1
    {
        private CalculateApi _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new CalculateApi();
        }

        [Test]
        public void CalculatePost_AddOperation_ReturnsCorrectResult()
        {
            var body = new CalculateBody { Number1 = 5, Number2 = 3 };
            var result = _controller.CalculatePost(body, "add") as OkObjectResult;
            var response = result?.Value as InlineResponse200;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(8, response.Result);
        }

        [Test]
        public void CalculatePost_SubtractOperation_ReturnsCorrectResult()
        {
            var body = new CalculateBody { Number1 = 10, Number2 = 4 };
            var result = _controller.CalculatePost(body, "subtract") as OkObjectResult;
            var response = result?.Value as InlineResponse200;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(6, response.Result);
        }

        [Test]
        public void CalculatePost_MultiplyOperation_ReturnsCorrectResult()
        {
            var body = new CalculateBody { Number1 = 7, Number2 = 6 };
            var result = _controller.CalculatePost(body, "multiply") as OkObjectResult;
            var response = result?.Value as InlineResponse200;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(42, response.Result);
        }

        [Test]
        public void CalculatePost_DivideOperation_ReturnsCorrectResult()
        {
            var body = new CalculateBody { Number1 = 20, Number2 = 4 };
            var result = _controller.CalculatePost(body, "divide") as OkObjectResult;
            var response = result?.Value as InlineResponse200;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(5, response.Result);
        }

        [Test]
        public void CalculatePost_DivideByZero_ReturnsBadRequest()
        {
            var body = new CalculateBody { Number1 = 10, Number2 = 0 };
            var result = _controller.CalculatePost(body, "divide") as BadRequestObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.That(result.Value.ToString(), Does.Contain("לא ניתן לחלק באפס"));
        }

        [Test]
        public void CalculatePost_InvalidOperation_ReturnsBadRequest()
        {
            var body = new CalculateBody { Number1 = 10, Number2 = 5 };
            var result = _controller.CalculatePost(body, "modulo") as BadRequestObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.That(result.Value.ToString(), Does.Contain("פעולה לא חוקית"));
        }
    }
}
