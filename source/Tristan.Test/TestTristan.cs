using fitlibrary;

namespace Tristan.Test {
    public class TestTristan: DoFixture {
        public TestTristan() {
            var players = new Players();
            draws = new Draws();
            playerService = new PlayerService(players, draws);
            drawService = new DrawService(players, draws);
        }

        public Draws Draws { get { return draws; } }

        readonly Draws draws;
        readonly DrawService drawService;
        readonly PlayerService playerService;
    }
}
