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
    }
}
