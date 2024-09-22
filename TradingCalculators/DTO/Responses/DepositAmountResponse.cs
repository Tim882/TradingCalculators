using TradingCalculators.Models;

namespace TradingCalculators.DTO.Responses
{
    public class DepositAmountResponse
    {
        public double FinalDepositAmount { get; set; }
        public List<DepositAmountState> DepositAmountStates { get; set; }
    }
}
