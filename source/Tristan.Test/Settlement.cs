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

        public Fixture CreateAccounts() {
            return new CreateAccounts(playerService);
        }

        public Fixture TicketsInTheDraw() {
            return new PurchaseTickets(playerService).WithDrawDate(drawDate);
        }

        public void DrawResultsAre(int[] numbers) {
            drawService.SettleDraw(drawDate, numbers);
        }

        public Fixture AccountsAfterTheDraw() {
            return new AccountsAfterTheDraw(playerService);
        }

        readonly DrawService drawService;
        readonly PlayerService playerService;
        readonly DateTime drawDate;
    }
}
