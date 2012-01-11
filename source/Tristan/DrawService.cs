using System;
using System.Collections.Generic;
using System.Linq;

namespace Tristan {
    public class DrawService {
        public DrawService(PlayerService playerService) {
            this.playerService = playerService;
        }

        public void CreateDraw(DateTime drawDate) {
            draws.Add(drawDate, new Draw(drawDate));
        }

        public Draw GetDraw(DateTime drawDate) {
            return draws[drawDate];
        }

        public void PurchaseTicket(DateTime drawDate, int playerId, int[] numbers, int count) {
            var player = playerService.GetPlayer(playerId);
            var cost = ticketCost*count;
            player.AdjustBalance(-cost);
            GetDraw(drawDate).AddTicket(playerId, numbers, cost);
        }

        public void SettleDraw(DateTime drawDate, int[] numbers) {
            var calculator = new WinningsCalculator();
            var draw = GetDraw(drawDate);
            var ticketCategories = draw.SplitTicketsIntoCategories(numbers);
            for (var matches = 0; matches <= numbers.Length; matches++) {
                var prizePool = calculator.GetPrizePool(matches, draw.TotalPoolSize*operatorDeductionFactor);
                var totalInCategory = ticketCategories[matches].Sum(ticket => ticket.Amount);
                foreach (var ticket in ticketCategories[matches]) {
                    var winnings = ticket.Amount*prizePool/totalInCategory;
                    playerService.GetPlayer(ticket.PlayerId).AdjustBalance(winnings);
                    ticket.Settle(winnings);
                }
            }
        }

        public IEnumerable<Ticket> GetTickets(int playerId) {
            return draws.Values.SelectMany(draw => draw.GetTickets(playerId));
        }

        public IEnumerable<Ticket> GetOpenTickets(int playerId) {
            return draws.Values.SelectMany(draw => draw.GetTickets(playerId)).Where(ticket => ticket.IsOpen);
        }

        public IEnumerable<Ticket> GetTickets(int playerId, DateTime drawDate) {
            return draws[drawDate].GetTickets(playerId);
        }

        const decimal ticketCost = 10M;

        readonly Dictionary<DateTime, Draw> draws = new Dictionary<DateTime,Draw>();
        readonly PlayerService playerService;
        const decimal operatorDeductionFactor = 0.5M;
    }
}
