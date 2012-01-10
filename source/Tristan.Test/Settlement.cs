using System;
using fit;
using fitlibrary;

namespace Tristan.Test {
    public class Settlement: DoFixture {
        public Settlement() {
            playerManager = new PlayerManager();
            drawManager = new DrawManager(playerManager);
            drawDate = DateTime.Now;
            drawManager.CreateDraw(drawDate);
        }

        public Fixture CreateAccounts() {
            return new CreateAccounts(playerManager);
        }

        public Fixture TicketsInTheDraw() {
            return new PurchaseTickets(playerManager, drawManager).WithDrawDate(drawDate);
        }

        public void DrawResultsAre(int[] numbers) {
            drawManager.SettleDraw(drawDate, numbers);
        }

        public Fixture AccountsAfterTheDraw() {
            return new AccountsAfterTheDraw(playerManager);
        }

        readonly DrawManager drawManager;
        readonly PlayerManager playerManager;
        readonly DateTime drawDate;
    }
}
