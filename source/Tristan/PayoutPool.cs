namespace Tristan {
    public class PayoutPool {
        public PayoutPool(decimal payoutAmount) {
            this.payoutAmount = payoutAmount;
        }

        public static int PoolPercentage(int matches) {
            switch (matches) {
                case 6: return 68;
                case 5: return 10;
                case 4: return 10;
                case 3: return 12;
                default: return 0;
            }
        }

        public decimal PrizePool(int matches) {
            return payoutAmount * PoolPercentage(matches)/100;
        }

        readonly decimal payoutAmount;
    }
}
