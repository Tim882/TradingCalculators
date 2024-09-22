namespace TradingCalculators.DTO.Requests
{
    public class TakeAndStopRequest
    {
        /// <summary>
        /// Стоимость в пунктах для рассчета в лонг
        /// </summary>
        public double NumOfPointsLong { get; set; }
        /// <summary>
        /// Стоимость в пунктах для рассчета в шорт
        /// </summary>
        public double NumOfPointsShort { get; set; }
        /// <summary>
        /// Процент тейка
        /// </summary>
        public double TakePercent { get; set; }
        /// <summary>
        /// Процент стопа
        /// </summary>
        public double StopPercent { get; set; }
    }
}
