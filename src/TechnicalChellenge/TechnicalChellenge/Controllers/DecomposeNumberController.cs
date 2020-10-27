using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace TechnicalChellenge.Controllers
{
    /// <summary>
    /// DecomposeNumberController.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DecomposeNumberController : ControllerBase
    {
        private readonly IDecomposeNumberService _decomposeNumberService;

        public DecomposeNumberController(IDecomposeNumberService decomposeNumberService)
        {
            this._decomposeNumberService = decomposeNumberService;
        }

        /// <summary>
        /// Calc Decompose Number
        /// </summary>
        /// <param name="number">Number Calc</param>
        /// <returns>Action Result</returns>
        [HttpGet]
        [Route("")]

        public IActionResult Get(long number)
        {
            try
            {
                var data = Task.Run(() => this._decomposeNumberService.CalcDecomposeNumber(number)).Result;

                return Ok(new
                {
                    data,
                    Success = 1,
                    Message = string.Empty,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = 0,
                    ex.Message
                });
            }
        }

        /// <summary>
        /// GetValidatePrime.
        /// </summary>
        /// <param name="number">number input.</param>
        /// <returns>True/False</returns>
        [HttpGet]
        [Route("prime")]
        public IActionResult GetValidatePrime(long number)
        {
            try
            {
                var data = Task.Run(() => this._decomposeNumberService.CalcDecomposeNumber(number)).Result;

                return Ok(new
                {
                    data,
                    Success = 1,
                    Message = string.Empty,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = 0,
                    ex.Message
                });
            }
        }
    }
}
