using System;
using fit;
using fitlibrary;

namespace Tristan.Test {
    public class Settlement: DoFixture {
        public Settlement() {
            var players = new Players();
            var draws = new Draws();
            playerService = new PlayerService(players, draws);
            drawService = new DrawService(players, draws);
            drawDate = DateTime.Now;
            drawService.CreateDraw(drawDate);
        }
/*
        public Fixture CreateAccounts() {
            return new CreateAccounts(playerService);
        }

        public Fixture TicketsInTheDraw() {
            return new PurchaseTicketsForDraw(playerService).WithDrawDate(drawDate);
        }

        public Fixture AccountsAfterTheDraw() {
            return new AccountsAfterTheDraw(playerService);
        }
*/
        public void DrawResultsAre(int[] numbers) {
            drawService.SettleDraw(drawDate, numbers);
        }

        readonly DrawService drawService;
        readonly PlayerService playerService;
        readonly DateTime drawDate;
    }
}
