namespace TradingCalculators.DTO.Responses
{
    public class TakeAndStopResponse
    {
        /// <summary>
        /// Стоимость в пунктах цены инструмента при достижении тейка в лонг
        /// </summary>
        public double LongTakePointPrice { get; set; }
        /// <summary>
        /// Стоимость в пунктах цены инструмента при достижении стопа в лонг
        /// </summary>
        public double LongStopPointPrice { get; set; }
        /// <summary>
        /// Стоимость в пунктах цены инструмента при достижении тейка в шорт
        /// </summary>
        public double ShortTakePointPrice { get; set; }
        /// <summary>
        /// Стоимость в пунктах цены инструмента при достижении стопа в шорт
        /// </summary>
        public double ShortStopPointPrice { get; set; }
    }
}
