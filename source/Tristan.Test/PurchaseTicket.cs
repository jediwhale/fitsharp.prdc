using System;
using fitlibrary;
using fitSharp.Fit.Engine;

namespace Tristan.Test {
    public class PurchaseTicket: DoFixture {
        public void PlayerDepositsDollarsWithCardAndExpiryDate(
                string userName, decimal amount, string card, string expiry) {
            var playerId = PlayerService.PlayerWithUserName(userName).PlayerId;
            PlayerService.DepositWithCard(playerId, card, expiry, amount);
        }

        public decimal AccountBalanceFor(string userName) {
            return PlayerService.PlayerWithUserName(userName).Balance;
        }

        public void PlayerBuysATicketWithNumbersForDrawOn(string userName, int[] numbers, DateTime drawDate) {
            PlayerBuysTicketsWithNumbersForDrawOn(userName, 1, numbers, drawDate);
        }

        public void PlayerBuysTicketsWithNumbersForDrawOn(string userName, int count, int[] numbers, DateTime drawDate) {
            var playerId = PlayerService.PlayerWithUserName(userName).PlayerId;
            PlayerService.PurchaseTicket(drawDate, playerId, numbers, count);
        }

        public decimal PoolValueForDrawOnIs(DateTime drawDate) {
            return PlayerService.PoolValueForDraw(drawDate);
        }

        public bool TicketWithNumbersForDollarsIsRegisteredForPlayerForDrawOn(
                int[] numbers, decimal amount, string userName, DateTime drawDate) {
            return PlayerService.Tickets(userName, drawDate, numbers)
                .ForFirst(ticket => ticket.Amount == amount, () => false);
        }

        PlayerService PlayerService { get { return Processor.GetSystemUnderTest<PlayerService>(); } }

    }
}
