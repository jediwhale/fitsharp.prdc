using fit;

namespace Tristan.Test {
    public class PrizeDistributionForPayoutPool: ColumnFixture {
        public int PoolPercentage() {
            return calculator.GetPoolPercentage(WinningCombination);
        }

        public decimal PrizePool() {
            var payoutPool = decimal.Parse(Args[0]);
            return calculator.GetPrizePool(WinningCombination, payoutPool);
        }

        public int WinningCombination;

        readonly WinningsCalculator calculator = new WinningsCalculator();
    }
}
