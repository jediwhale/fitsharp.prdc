using fitlibrary;
using fitSharp.Fit.Engine;

namespace Tristan.Test {
    public class CreateAccounts: SetUpFixture {
        public void PlayerBalance(string name, decimal balance) {
            var playerService = Processor.GetSystemUnderTest<PlayerService>();
            var registration = new PlayerRegistration {UserName = name};
            playerService.Register(registration);
            playerService.PlayerWithUserName(name).AdjustBalance(balance);
        }
    }
}
