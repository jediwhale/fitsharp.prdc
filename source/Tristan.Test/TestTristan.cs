using System;
using System.Collections.Generic;
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

        public void DrawResultsForAre(DateTime drawDate, int[] numbers) {
            drawService.SettleDraw(drawDate, numbers);
        }

        public IEnumerable<Ticket> ViewTicketsForPlayerInDraw(string name, DateTime drawDate) {
            return playerService.ViewTicketsForPlayer(name, drawDate);
        }

        readonly Draws draws;
        readonly DrawService drawService;
        readonly PlayerService playerService;
    }
}
