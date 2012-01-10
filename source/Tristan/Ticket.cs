using System;
using System.Linq;

namespace Tristan {
    public class Ticket {
        public Ticket(int playerId, DateTime drawDate, decimal amount, int[] numbers) {
            PlayerId = playerId;
            Amount = amount;
            Numbers = numbers;
            DrawDate = drawDate;
            IsOpen = true;
        }

        public int CountMatches(int[] drawNumbers) {
            return drawNumbers.Count(drawNumber => Numbers.Contains(drawNumber));
        }

        public void Settle(decimal winnings) {
            Winnings = winnings;
            IsOpen = false;
        }

        public int PlayerId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime DrawDate {get; private set; }
        public bool IsOpen { get; private set; }
        public decimal Winnings { get; private set; }
        public int[] Numbers { get; private set; }
    }
}
