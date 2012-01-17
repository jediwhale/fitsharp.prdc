using fit;

namespace Tristan.Test {
    public class LogIn: ColumnFixture {
        public LogIn(PlayerService playerService) {
            this.playerService = playerService;
        }
        
        public string UserName;
        public string Password;

        public override void Execute() {
            SetSystemUnderTest(playerService.Login(UserName, Password));
        }

        readonly PlayerService playerService;
    }
}
