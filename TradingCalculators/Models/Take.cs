namespace TradingCalculators.Models
{
    public class Take
    {
        /// <summary>
        /// Изменение в процентах от первоначальной цены
        /// </summary>
        public double ChangePercent { get; set; }
        /// <summary>
        /// Количество лотов в тейке
        /// </summary>
        public long NumOfLots { get; set; }
    }
}
