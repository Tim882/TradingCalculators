using TradingCalculators.Calculators.Interfaces;
using TradingCalculators.DTO.Requests;
using TradingCalculators.DTO.Responses;
using TradingCalculators.Models;

namespace TradingCalculators.Calculators.Services
{
    public class CalculatorsDataService : ICalculatorsDataService
    {
        public DepositAmountResponse CalculateDepositAmount(DepositAmountRequest depositAmountRequest)
        {
            DepositAmountResponse depositAmountResponse = new DepositAmountResponse();
            depositAmountResponse.DepositAmountStates = new List<DepositAmountState>
            { 
                new DepositAmountState { 
                    Date = depositAmountRequest.DateStart, 
                    DepositAmount =  depositAmountRequest.DepositAmount
                }
            };
            
            for(int i = 1; i <= depositAmountRequest.NumOfMonths; i++)
            {
                DepositAmountState lastDepositAmountState = depositAmountResponse.DepositAmountStates.LastOrDefault();

                DepositAmountState depositAmountState = new DepositAmountState();
                depositAmountState.Date = (DateTime)(lastDepositAmountState?.Date.AddMonths(1));
                depositAmountState.DepositAmount = lastDepositAmountState.DepositAmount + lastDepositAmountState.DepositAmount * depositAmountRequest.Leverage * depositAmountRequest.DayDepositProfitPercent / 100 * 20;

                depositAmountResponse.DepositAmountStates.Add(depositAmountState);
            }

            depositAmountResponse.FinalDepositAmount = depositAmountResponse.DepositAmountStates.LastOrDefault()?.DepositAmount ?? 0;

            return depositAmountResponse;
        }

        public TakeAndStopResponse CalculateTakeAndStop(TakeAndStopRequest takeAndStopRequest)
        {
            TakeAndStopResponse takeAndStopResponse = new TakeAndStopResponse();

            // Рассчет для лонгового значения
            takeAndStopResponse.LongTakePointPrice = CalculatePercentChange(
                takeAndStopRequest.NumOfPointsLong, 
                takeAndStopRequest.TakePercent);
            takeAndStopResponse.LongStopPointPrice = CalculatePercentChange(
                takeAndStopRequest.NumOfPointsLong, 
                takeAndStopRequest.StopPercent,
                false);

            // Рассчет для шортового значения
            takeAndStopResponse.ShortTakePointPrice = CalculatePercentChange(
                takeAndStopRequest.NumOfPointsShort,
                takeAndStopRequest.TakePercent, false);
            takeAndStopResponse.ShortStopPointPrice = CalculatePercentChange(
                takeAndStopRequest.NumOfPointsShort,
                takeAndStopRequest.StopPercent);

            return takeAndStopResponse;
        }

        /// <summary>
        /// Метод для расчета новой цены по изменению в процентах
        /// </summary>
        /// <param name="price">Старая цена</param>
        /// <param name="percent">Изменение цены в процентах</param>
        /// <param name="isLong">Изменение при движении цены вверх или вниз (по умолчанию вверх)</param>
        /// <returns></returns>
        private double CalculatePercentChange(double price, double percent, bool isLong = true)
        {
            if (isLong)
            {
                return price * (1 + percent / 100);
            }
            else
            {
                return price - price * percent / 100;
            }
        }
    }
}
