using fitlibrary;

namespace Tristan.Test {
    public class CalculatePrizesForPayoutPool: CalculateFixture {
        public int PoolPercentageMatches(int matches) {
            return PayoutPool.PoolPercentage(matches);
        }

        public decimal PrizePoolMatches(int matches) {
            return new PayoutPool(GetArgumentInput<decimal>(0)).PrizePool(matches);
        }
    }
}
