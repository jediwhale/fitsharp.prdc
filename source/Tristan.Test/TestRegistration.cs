using fitlibrary;

namespace Tristan.Test {
    public class TestRegistration: DoFixture {
        public TestRegistration() {
            var players = new Players();
            var draws = new Draws();
            playerService = new PlayerService(players, draws);
            SetSystemUnderTest(playerService);
        }

        public RegisterPlayers RegisterPlayers() { return new RegisterPlayers(playerService);}
        public LogIn LogIn() { return new LogIn(playerService);}

        readonly PlayerService playerService;
    }
}
