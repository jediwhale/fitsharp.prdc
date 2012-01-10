using System;
using fitlibrary;

namespace Tristan.Test {
    public class PurchaseTicket: DoFixture {
        public void PlayerDepositsDollarsWithCardAndExpiryDate(
                string userName, decimal amount, string card, string expiry) {
            var playerId = SetUpTestEnvironment.PlayerManager.GetPlayer(userName).PlayerId;
            SetUpTestEnvironment.PlayerManager.DepositWithCard(playerId, card, expiry, amount);
        }

        public decimal AccountBalanceFor(string userName) {
            return SetUpTestEnvironment.PlayerManager.GetPlayer(userName).Balance;
        }

        public void PlayerBuysATicketWithNumbersForDrawOn(string userName, int[] numbers, DateTime drawDate) {
            PlayerBuysTicketsWithNumbersForDrawOn(userName, 1, numbers, drawDate);
        }

        public void PlayerBuysTicketsWithNumbersForDrawOn(string userName, int count, int[] numbers, DateTime drawDate) {
            var playerId = SetUpTestEnvironment.PlayerManager.GetPlayer(userName).PlayerId;
            SetUpTestEnvironment.DrawManager.PurchaseTicket(drawDate, playerId, numbers, count);
        }

        public decimal PoolValueForDrawOnIs(DateTime drawDate) {
            return SetUpTestEnvironment.DrawManager.GetDraw(drawDate).TotalPoolSize;
        }

        public bool TicketWithNumbersForDollarsIsRegisteredForPlayerForDrawOn(
                int[] numbers, decimal amount, string userName, DateTime drawDate) {
            var ticket = SetUpTestEnvironment.DrawManager.GetDraw(drawDate).GetTicket(numbers);
            return ticket.PlayerId == SetUpTestEnvironment.PlayerManager.GetPlayer(userName).PlayerId
                && ticket.Amount == amount;
        }
    }
}
