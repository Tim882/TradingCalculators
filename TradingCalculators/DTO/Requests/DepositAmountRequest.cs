namespace TradingCalculators.DTO.Requests
{
    public class DepositAmountRequest
    {
        /// <summary>
        /// Начальный размер депозита
        /// </summary>
        public double DepositAmount { get; set; }
        /// <summary>
        /// Размер кредитного плеча
        /// </summary>
        public double Leverage { get; set; } = 1;
        /// <summary>
        /// Дата начала рассчета
        /// </summary>
        public DateTime DateStart { get; set; } = DateTime.Now;
        /// <summary>
        /// Количество месяцев вперед, на которое делается рассчет
        /// </summary>
        public int NumOfMonths { get; set; }
        /// <summary>
        /// Прибыль в день на депозит в процентах
        /// </summary>
        public double DayDepositProfitPercent { get; set; } = 1;
    }
}
