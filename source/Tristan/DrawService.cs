using System;
using System.Collections.Generic;
using System.Linq;

namespace Tristan {
    public class DrawService {
        public DrawService(Players players, Draws draws) {
            this.players = players;
            this.draws = draws;
        }

        public void CreateDraw(DateTime drawDate) {
            draws.Add(new Draw(drawDate));
        }

        public void SettleDraw(DateTime drawDate, int[] numbers) {
            var draw = draws[drawDate];
            var payoutPool = new PayoutPool(draw.TotalPoolSize * operatorDeductionFactor);
            var ticketCategories = draw.SplitTicketsIntoCategories(numbers);
            for (var matches = 0; matches <= numbers.Length; matches++) {
                var prizePool = payoutPool.PrizePool(matches);
                var totalInCategory = ticketCategories[matches].Sum(ticket => ticket.Amount);
                foreach (var ticket in ticketCategories[matches]) {
                    var winnings = ticket.Amount*prizePool/totalInCategory;
                    players[ticket.PlayerId].AdjustBalance(winnings);
                    ticket.Settle(winnings);
                }
            }
        }

        readonly Players players;
        readonly Draws draws;
        const decimal operatorDeductionFactor = 0.5M;
    }
}
