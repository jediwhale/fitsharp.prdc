using System;
using fitlibrary;

namespace Tristan.Test {
    public class PurchaseTickets: SetUpFixture {
        public PurchaseTickets(PlayerManager playerManager, DrawManager drawManager) {
            this.playerManager = playerManager;
            this.drawManager = drawManager;
        }

        public PurchaseTickets WithDrawDate(DateTime drawDate) {
            defaultDrawDate = drawDate;
            return this;
        }

        public void PlayerNumbersCount(string name, int[] numbers, int count) {
            PlayerDrawNumbersCount(name, defaultDrawDate, numbers, count);
        }

        public void PlayerDrawNumbersCount(string name, DateTime drawDate, int[] numbers, int count) {
            drawManager.PurchaseTicket(drawDate, playerManager.GetPlayer(name).PlayerId, numbers, count);
        }

        readonly DrawManager drawManager;
        readonly PlayerManager playerManager;
        DateTime defaultDrawDate;
    }
}
