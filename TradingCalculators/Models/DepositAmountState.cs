namespace TradingCalculators.Models
{
    public class DepositAmountState
    {
        /// <summary>
        /// Дата, на которую приходятся данные о состонии депозита
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Размер депозита
        /// </summary>
        public double DepositAmount { get; set; }
    }
}
