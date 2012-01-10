using fitlibrary;

namespace Tristan.Test {
    public class CreateAccounts: SetUpFixture {
        public CreateAccounts(PlayerManager playerManager) {
            this.playerManager = playerManager;
        }

        public void PlayerBalance(string name, decimal balance) {
            var registration = new PlayerRegistrationInfo {UserName = name};
            var playerId = playerManager.RegisterPlayer(registration);
            playerManager.GetPlayer(playerId).AdjustBalance(balance);
        }

        readonly PlayerManager playerManager;
    }
}
