using System;
using fitlibrary;

namespace Tristan.Test {
    public class PurchaseTickets: SetUpFixture {
        public PurchaseTickets(PlayerService playerService, DrawService drawService) {
            this.playerService = playerService;
            this.drawService = drawService;
        }

        public PurchaseTickets WithDrawDate(DateTime drawDate) {
            defaultDrawDate = drawDate;
            return this;
        }

        public void PlayerNumbersCount(string name, int[] numbers, int count) {
            PlayerDrawNumbersCount(name, defaultDrawDate, numbers, count);
        }

        public void PlayerDrawNumbersCount(string name, DateTime drawDate, int[] numbers, int count) {
            drawService.PurchaseTicket(drawDate, playerService.GetPlayer(name).PlayerId, numbers, count);
        }

        readonly DrawService drawService;
        readonly PlayerService playerService;
        DateTime defaultDrawDate;
    }
}
