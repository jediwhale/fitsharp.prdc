using System;
using fitlibrary;

namespace Tristan.Test {
    public class PurchaseTicket: DoFixture {
        public PurchaseTicket(TestPlayerService playerService) {
            this.playerService = playerService;
        }

        public void PlayerDepositsDollarsWithCardAndExpiryDate(
                string userName, decimal amount, string card, string expiry) {
            var playerId = playerService.PlayerService.GetPlayer(userName).PlayerId;
            playerService.PlayerService.DepositWithCard(playerId, card, expiry, amount);
        }

        public decimal AccountBalanceFor(string userName) {
            return playerService.PlayerService.GetPlayer(userName).Balance;
        }

        public void PlayerBuysATicketWithNumbersForDrawOn(string userName, int[] numbers, DateTime drawDate) {
            PlayerBuysTicketsWithNumbersForDrawOn(userName, 1, numbers, drawDate);
        }

        public void PlayerBuysTicketsWithNumbersForDrawOn(string userName, int count, int[] numbers, DateTime drawDate) {
            var playerId = playerService.PlayerService.GetPlayer(userName).PlayerId;
            playerService.DrawService.PurchaseTicket(drawDate, playerId, numbers, count);
        }

        public decimal PoolValueForDrawOnIs(DateTime drawDate) {
            return playerService.DrawService.GetDraw(drawDate).TotalPoolSize;
        }

        public bool TicketWithNumbersForDollarsIsRegisteredForPlayerForDrawOn(
                int[] numbers, decimal amount, string userName, DateTime drawDate) {
            var ticket = playerService.DrawService.GetDraw(drawDate).GetTicket(numbers);
            return ticket.PlayerId == playerService.PlayerService.GetPlayer(userName).PlayerId
                && ticket.Amount == amount;
        }

        readonly TestPlayerService playerService;
    }
}
