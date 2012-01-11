using System;
using fit;
using fitlibrary;

namespace Tristan.Test {
    public class Settlement: DoFixture {
        public Settlement() {
            playerService = new PlayerService();
            drawService = new DrawService(playerService);
            drawDate = DateTime.Now;
            drawService.CreateDraw(drawDate);
        }

        public Fixture CreateAccounts() {
            return new CreateAccounts(playerService);
        }

        public Fixture TicketsInTheDraw() {
            return new PurchaseTickets(playerService, drawService).WithDrawDate(drawDate);
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
