using System;
using fitlibrary;
using fitSharp.Fit.Engine;

namespace Tristan.Test {
    public class PurchaseTicket: DoFixture {
        public void PlayerDepositsDollarsWithCardAndExpiryDate(
                string userName, decimal amount, string card, string expiry) {
            PlayerService.DepositWithCard(userName, card, expiry, amount);
        }

        public void PlayerBuysTicketsWithNumbersForDrawOn(string userName, int count, int[] numbers, DateTime drawDate) {
            PlayerService.PurchaseTicket(drawDate, userName, numbers, count);
        }

        public bool TicketWithNumbersForDollarsIsRegisteredForPlayerForDrawOn(
                int[] numbers, decimal amount, string userName, DateTime drawDate) {
            return PlayerService.Tickets(userName, drawDate, numbers)
                .ForFirst(ticket => ticket.Amount == amount, () => false);
        }

        public decimal PoolValueForDraw(DateTime drawDate) {
            var test = Processor.GetSystemUnderTest<TestTristan>();
            return test.Draws[drawDate].TotalPoolSize;
        }

        PlayerService PlayerService { get { return Processor.GetSystemUnderTest<PlayerService>(); } }
    }
}
