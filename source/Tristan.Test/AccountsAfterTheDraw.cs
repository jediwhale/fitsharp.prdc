using fit;
using fitSharp.Fit.Engine;

namespace Tristan.Test {
    public class AccountsAfterTheDraw: ColumnFixture {
        public string Player;

        public decimal Balance {
            get {
                var playerService = Processor.GetSystemUnderTest<PlayerService>();
                return playerService.PlayerWithUserName(Player).Balance;
            }
        }
    }
}
