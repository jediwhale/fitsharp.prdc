using fit;

namespace Tristan.Test {
    public class AccountsAfterTheDraw: ColumnFixture {
        public AccountsAfterTheDraw(PlayerManager playerManager) {
            this.playerManager = playerManager;
        }

        public string Player;
        public decimal Balance {
            get {
                return playerManager.GetPlayer(Player).Balance;
            }
        }

        readonly PlayerManager playerManager;
    }
}
