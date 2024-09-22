using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradingCalculators.Calculators.Interfaces;
using TradingCalculators.DTO.Requests;
using TradingCalculators.DTO.Responses;

namespace TradingCalculators.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorsController : ControllerBase
    {
        private readonly ICalculatorsDataService _calculatorsDataService;

        public CalculatorsController(ICalculatorsDataService calculatorsDataService)
        {
            _calculatorsDataService = calculatorsDataService;
        }

        /// <summary>
        /// Метод получения финансового результата по позиции
        /// </summary>
        /// <returns></returns>
        [HttpGet("/position/trading/result")]
        public IActionResult PositionTradingResult()
        {
            return NotFound();
        }

        /// <summary>
        /// Прогноз будущего депозита на основе среднемесячного заработка
        /// </summary>
        /// <param name="depositAmountRequest">Параметры запроса</param>
        /// <returns></returns>
        [HttpPost("/deposit/forecast")]
        public IActionResult DepositAmount([FromBody] DepositAmountRequest depositAmountRequest)
        {
            try
            {
                DepositAmountResponse depositAmountResponse = _calculatorsDataService.CalculateDepositAmount(depositAmountRequest);

                return Ok(depositAmountResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Прогноз дохода за месяц (20 торговых дней) при заданных параметрах
        /// </summary>
        /// <returns></returns>
        [HttpGet("/winrate/result")]
        public IActionResult WinrateResult()
        {
            return NotFound();
        }

        /// <summary>
        /// Калькулятор тейков и стопов
        /// </summary>
        /// <param name="takeAndStopRequest">Параметры запроса</param>
        /// <returns></returns>
        [HttpPost("/application")]
        public IActionResult TakeAndStop([FromBody] TakeAndStopRequest takeAndStopRequest)
        {
            try
            {
                TakeAndStopResponse takeAndStopResponse = _calculatorsDataService.CalculateTakeAndStop(takeAndStopRequest);

                return Ok(takeAndStopResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Калькулятор среднего дохода в процентах при заданных тейках
        /// </summary>
        /// <returns></returns>
        [HttpGet("/income/average")]
        public IActionResult CalculateAverage()
        {
            return NotFound();
        }
    }
}
