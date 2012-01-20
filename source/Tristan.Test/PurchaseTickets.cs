using System;
using fitlibrary;

namespace Tristan.Test {
    public class PurchaseTickets: SetUpFixture {
        public PurchaseTickets(PlayerService playerService) {
            this.playerService = playerService;
        }

        public PurchaseTickets WithDrawDate(DateTime drawDate) {
            defaultDrawDate = drawDate;
            return this;
        }

        public void PlayerNumbersCount(string name, int[] numbers, int count) {
            PlayerDrawNumbersCount(name, defaultDrawDate, numbers, count);
        }

        public void PlayerDrawNumbersCount(string userName, DateTime drawDate, int[] numbers, int count) {
            playerService.PurchaseTicket(drawDate, userName, numbers, count);
        }

        readonly PlayerService playerService;
        DateTime defaultDrawDate;
    }
}
