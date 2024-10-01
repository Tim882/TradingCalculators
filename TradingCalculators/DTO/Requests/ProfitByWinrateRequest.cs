namespace TradingCalculators.DTO.Requests
{
    public class ProfitByWinrateRequest
    {
        /// <summary>
        /// Сумма сделки
        /// </summary>
        public double Sum { get; set; }
        /// <summary>
        /// Тейк в процентах согласно стратегии
        /// </summary>
        public double TakePercent { get; set; }
        /// <summary>
        /// Стоп в процентах согласно стратегии
        /// </summary>
        public double StopPercent { get; set; }
        /// <summary>
        /// Количество успешных сделок за период
        /// </summary>
        public long NumOfSuccessDeals { get; set; }
        /// <summary>
        /// Количество сделок, выбитых по стопу
        /// </summary>
        public long NumOfFailureDeals { get; set; }
        /// <summary>
        /// Комиссия в процентах от оборота
        /// </summary>
        public double RatePercent { get; set; }
    }
}
