using System;
using fitlibrary;

namespace Tristan.Test {
    public class TestTristan: DoFixture {
        public TestTristan() {
            var players = new Players();
            draws = new Draws();
            playerService = new TestPlayerService(new PlayerService(players, draws));
            drawService = new DrawService(players, draws);
        }

        public Draws Draws { get { return draws; } }

        public void DrawResultsForAre(DateTime drawDate, int[] numbers) {
            drawService.SettleDraw(drawDate, numbers);
        }

        readonly Draws draws;
        readonly DrawService drawService;
        readonly TestPlayerService playerService;
    }
}
