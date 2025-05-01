using System;
using Microsoft.AspNetCore.Mvc;
using IO.Swagger.Models;
//using IO.Swagger.Security;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;      

namespace IO.Swagger.Controllers
{
    /// <summary>
    /// Provides basic math operations.
    /// </summary>
    [ApiController]
    public class CalculateApi : ControllerBase
    {
        /// <summary>
        /// Performs a math operation (add, subtract, multiply, divide) on two numbers.
        /// </summary>
        /// <param name="body">Object with number1 and number2.</param>
        /// <param name="xOperation">The operation to perform.</param>
        /// <returns>The result of the operation.</returns>
        /// <response code="200">Calculation successful.</response>
        /// <response code="400">Bad request (invalid operation or missing data).</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="500">Calculation error (e.g. divide by zero).</response>

        [Authorize]
        [HttpPost]
        [Route("/lital-e6f/calculateApi/1.0.0/calculate")]
        public IActionResult CalculatePost([FromBody] CalculateBody body, [FromHeader] string xOperation)
        {
            if (body == null || !body.Number1.HasValue || !body.Number2.HasValue || string.IsNullOrWhiteSpace(xOperation))
            {
                return BadRequest("חסרים פרמטרים בבקשה.");
            }

            decimal number1 = body.Number1.Value;
            decimal number2 = body.Number2.Value;
            decimal result;

            try
            {
                switch (xOperation.Trim().ToLowerInvariant())
                {
                    case "add":
                        result = number1 + number2;
                        break;
                    case "subtract":
                        result = number1 - number2;
                        break;
                    case "multiply":
                        result = number1 * number2;
                        break;
                    case "divide":
                        if (number2 == 0)
                            return BadRequest("לא ניתן לחלק באפס.");
                        result = number1 / number2;
                        break;
                    default:
                        return BadRequest("פעולה לא חוקית.");
                }

                // Return the result in the response model
                var response = new InlineResponse200
                {
                    Result = result
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"שגיאת חישוב: {ex.Message}");
            }
        }

    }
}