namespace TradingCalculators.DTO.Requests
{
    public class PositionTradingResultRequest
    {
        /// <summary>
        /// Стоимость в пунктах
        /// </summary>
        public double NumOfPoints { get; set; }
        /// <summary>
        /// Стоимость пункта цены (для акций по умолчанию равно 1.0)
        /// </summary>
        public double POintPrice { get; set; } = 1.0;
    }
}
