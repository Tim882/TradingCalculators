using TradingCalculators.Calculators.Interfaces;
using TradingCalculators.DTO.Requests;
using TradingCalculators.DTO.Responses;
using TradingCalculators.Models;

namespace TradingCalculators.Calculators.Services
{
    public class CalculatorsDataService : ICalculatorsDataService
    {
        public AverageFromTakesResponse CalculateAverageFromTakes(AverageFromTakesRequest averageFromTakesRequest)
        {
            AverageFromTakesResponse averageFromTakesResponse = new AverageFromTakesResponse();

            double result = 0;
            double lotPrice = averageFromTakesRequest.PositionSum / averageFromTakesRequest.NumOfLots;

            foreach (var take in averageFromTakesRequest.Takes)
            {
                result += CalculatePercentChange(lotPrice * take.NumOfLots, take.ChangePercent, averageFromTakesRequest.IsLong);
            }

            averageFromTakesResponse.ResultPercent = result / averageFromTakesRequest.PositionSum;

            return averageFromTakesResponse;
        }

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
                depositAmountState.DepositAmount = depositAmountRequest.DepositReplenishment + lastDepositAmountState.DepositAmount + lastDepositAmountState.DepositAmount * depositAmountRequest.Leverage * depositAmountRequest.DayDepositProfitPercent / 100 * 20;

                depositAmountResponse.DepositAmountStates.Add(depositAmountState);
            }

            depositAmountResponse.FinalDepositAmount = depositAmountResponse.DepositAmountStates.LastOrDefault()?.DepositAmount ?? 0;

            return depositAmountResponse;
        }

        public ProfitByWinrateResponse CalculateProfitByWinrate(ProfitByWinrateRequest profitByWinrateRequest)
        {
            ProfitByWinrateResponse profitByWinrateResponse = new ProfitByWinrateResponse();

            var r = CalculatePercentChange(profitByWinrateRequest.Sum, profitByWinrateRequest.TakePercent);

            double profit = Math.Abs(profitByWinrateRequest.Sum - CalculatePercentChange(profitByWinrateRequest.Sum, profitByWinrateRequest.TakePercent)) - profitByWinrateRequest.Sum * profitByWinrateRequest.RatePercent / 50;
            double loss = Math.Abs(profitByWinrateRequest.Sum - CalculatePercentChange(profitByWinrateRequest.Sum, profitByWinrateRequest.StopPercent)) + profitByWinrateRequest.Sum * profitByWinrateRequest.RatePercent / 50;

            profitByWinrateResponse.Profit = profit * profitByWinrateRequest.NumOfSuccessDeals - loss * profitByWinrateRequest.NumOfFailureDeals;

            return profitByWinrateResponse;
        }

        /// <summary>
        /// Метод расчета результата по позиции
        /// </summary>
        /// <param name="positionTradingResultRequest">Параметры для расчета</param>
        /// <returns>Финансовый результат по позиции</returns>
        public PositionTradingResultResponse CalculatePositionTradingResult(PositionTradingResultRequest positionTradingResultRequest)
        {
            PositionTradingResultResponse positionTradingResultResponse = new PositionTradingResultResponse();

            double instrumentClosePrice = CalculatePercentChange(
                positionTradingResultRequest.NumOfPoints,
                positionTradingResultRequest.ChangePercent,
                positionTradingResultRequest.IsLongPostion);

            double openPrice = CalculatePositionPrice(
                    positionTradingResultRequest.NumOfPoints,
                    positionTradingResultRequest.NumOfLots,
                    positionTradingResultRequest.PointPrice,
                    positionTradingResultRequest.NumInLots);
            double closePrice = CalculatePositionPrice(
                    instrumentClosePrice,
                    positionTradingResultRequest.NumOfLots,
                    positionTradingResultRequest.PointPrice,
                    positionTradingResultRequest.NumInLots);

            if (positionTradingResultRequest.IsLongPostion)
            {
                openPrice *= -1;
            }
            else
            {
                closePrice *= -1;
            }

            double openPositionRate = CalculateRate(openPrice, positionTradingResultRequest.RatePercent);
            double closePositionRate = CalculateRate(closePrice, positionTradingResultRequest.RatePercent);

            double result = openPrice + closePrice - openPositionRate - closePositionRate;

            positionTradingResultResponse.Result = result;

            return positionTradingResultResponse;
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
                return price + price * percent / 100;
            }
            else
            {
                return price - price * percent / 100;
            }
        }

        /// <summary>
        /// Метод расчет стоимости позиции
        /// </summary>
        /// <param name="NumOfPoints">Стоимость инструмента в пунктах</param>
        /// <param name="NumOfLots">Количество лотов</param>
        /// <param name="PointPrice">Стоимость пункта цены</param>
        /// <param name="NumInLots">Количество единиц инструмента в лоте</param>
        /// <returns>Стоимость позиции</returns>
        private double CalculatePositionPrice(double NumOfPoints, long NumOfLots, double PointPrice = 1, long NumInLots = 1)
        {
            double price = NumOfPoints * NumInLots * PointPrice * NumOfLots;

            return price;
        }

        /// <summary>
        /// Метод для рассчета комиссии при открытии/закрытии позиции
        /// </summary>
        /// <param name="price">Стоимость позиции</param>
        /// <param name="ratePercent">Процент от позиции</param>
        /// <returns></returns>
        private double CalculateRate(double price, double ratePercent)
        {
            double rate = Math.Abs(price) * ratePercent / 100;

            return rate;
        }
    }
}
