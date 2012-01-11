using fit;

namespace Tristan.Test {
    public class PrizeDistributionForPayoutPool: ColumnFixture {
        public int PoolPercentage() {
            return PayoutPool.PoolPercentage(Matches);
        }

        public decimal PrizePool() {
            var payoutPool = new PayoutPool(decimal.Parse(Args[0]));
            return payoutPool.PrizePool(Matches);
        }

        public int Matches;
    }
}
