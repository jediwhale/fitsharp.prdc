using fitlibrary;

namespace Tristan.Test {
    public class CreateAccounts: SetUpFixture {
        public CreateAccounts(PlayerService playerService) {
            this.playerService = playerService;
        }

        public void PlayerBalance(string name, decimal balance) {
            var registration = new PlayerRegistration {UserName = name};
            playerService.Register(registration);
            playerService.PlayerWithUserName(name).AdjustBalance(balance);
        }

        readonly PlayerService playerService;
    }
}
