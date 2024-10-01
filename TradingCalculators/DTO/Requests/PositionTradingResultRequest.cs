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
        public double PointPrice { get; set; } = 1.0;
        /// <summary>
        /// Количество лотов
        /// </summary>
        public long NumOfLots { get; set; }
        /// <summary>
        /// Количество единиц инструмента в лоте (по умолчанию 1)
        /// </summary>
        public long NumInLots { get; set; }
        /// <summary>
        /// Изменение стоимости инструмента в процентах
        /// </summary>
        public double ChangePercent { get; set; }
        /// <summary>
        /// Размер комиссии в процентах от цены инструмента
        /// </summary>
        public double RatePercent { get; set; }
        /// <summary>
        /// Лонговая или шортовая позиция
        /// </summary>
        public bool IsLongPostion { get; set; }
    }
}
