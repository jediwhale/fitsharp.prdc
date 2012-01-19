using fit;

namespace Tristan.Test {
    public class AccountsAfterTheDraw: ColumnFixture {
        public AccountsAfterTheDraw(PlayerService playerService) {
            this.playerService = playerService;
        }

        public string Player;
        public decimal Balance {
            get {
                return playerService.PlayerWithUserName(Player).Balance;
            }
        }

        readonly PlayerService playerService;
    }
}
