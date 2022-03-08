using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
       

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var sun = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                return Ok(sun.ToString());
            }
            return BadRequest("Imput inválido");
        }



        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var sun = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

                return Ok(sun.ToString());
            }
            return BadRequest("Imput inválido");
        }


        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var sun = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

                return Ok(sun.ToString());
            }
            return BadRequest("Imput inválido");
        }




        [HttpGet("media/{firstNumber}/{secondNumber}")]
        public IActionResult media(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var sun = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber))/ 2;

                return Ok(sun.ToString());
            }
            return BadRequest("Imput inválido");
        }


        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number) ;
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }


    }
}
