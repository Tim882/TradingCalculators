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
        /// <param name="positionTradingResultRequest">Параметры запроса</param>
        /// <returns>Финансовый результат по позиции</returns>
        [HttpPost("/position/trading/result")]
        public IActionResult PositionTradingResult([FromBody] PositionTradingResultRequest positionTradingResultRequest)
        {
            try
            {
                PositionTradingResultResponse positionTradingResultResponse = _calculatorsDataService.CalculatePositionTradingResult(positionTradingResultRequest);
                
                return Ok(positionTradingResultResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
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
        [HttpPost("/winrate/result")]
        public IActionResult WinrateResult([FromBody] ProfitByWinrateRequest profitByWinrateRequest)
        {
            try
            {
                ProfitByWinrateResponse profitByWinrateResponse = _calculatorsDataService.CalculateProfitByWinrate(profitByWinrateRequest);

                return Ok(profitByWinrateResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
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
        [HttpPost("/income/average")]
        public IActionResult CalculateAverage([FromBody] AverageFromTakesRequest averageFromTakesRequest)
        {
            try
            {
                AverageFromTakesResponse averageFromTakesResponse = _calculatorsDataService.CalculateAverageFromTakes(averageFromTakesRequest);
                
                return Ok(averageFromTakesResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
