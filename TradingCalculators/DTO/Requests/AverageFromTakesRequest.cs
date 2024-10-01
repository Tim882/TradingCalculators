using TradingCalculators.Models;

namespace TradingCalculators.DTO.Requests
{
    public class AverageFromTakesRequest
    {
        /// <summary>
        /// Массив тейков
        /// </summary>
        public List<Take> Takes { get; set; }
        /// <summary>
        /// Общая стоимость активов в позиции
        /// </summary>
        public double PositionSum { get; set; }
        /// <summary>
        /// Количество лотов в позиции
        /// </summary>
        public long NumOfLots { get; set; }
        /// <summary>
        /// Флаг лоноговая ли позиция
        /// </summary>
        public bool IsLong {  get; set; }
    }
}
