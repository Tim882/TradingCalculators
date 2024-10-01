using TradingCalculators.DTO.Requests;
using TradingCalculators.DTO.Responses;

namespace TradingCalculators.Calculators.Interfaces
{
    public interface ICalculatorsDataService
    {
        /// <summary>
        /// Метод для получения таблицы изменения депозита и итогового результата
        /// </summary>
        /// <param name="depositAmountRequest">Параметры для рассчета</param>
        /// <returns></returns>
        public DepositAmountResponse CalculateDepositAmount(DepositAmountRequest depositAmountRequest);
        /// <summary>
        /// Метод для расчета тейков и стопов одного инструмента
        /// </summary>
        /// <param name="takeAndStopResponse">Параметры для рассчета</param>
        /// <returns></returns>
        public TakeAndStopResponse CalculateTakeAndStop(TakeAndStopRequest takeAndStopRequest);
        /// <summary>
        /// Метод для расчета финансового результата по позиции
        /// </summary>
        /// <param name="positionTradingResultRequest"></param>
        /// <returns></returns>
        public PositionTradingResultResponse CalculatePositionTradingResult(PositionTradingResultRequest positionTradingResultRequest);
        /// <summary>
        /// Метод вычисления среднего результата в процентах по тейкам
        /// </summary>
        /// <param name="averageFromTakesRequest">Параметры для рассчета</param>
        /// <returns></returns>
        public AverageFromTakesResponse CalculateAverageFromTakes(AverageFromTakesRequest averageFromTakesRequest);
        /// <summary>
        /// Метод вычисления прибыли по винрейту
        /// </summary>
        /// <param name="profitByWinrateResponse">Параметры для рассчета</param>
        /// <returns></returns>
        public ProfitByWinrateResponse CalculateProfitByWinrate(ProfitByWinrateRequest profitByWinrateRequest);
    }
}
