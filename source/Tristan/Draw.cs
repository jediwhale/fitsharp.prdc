using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tristan {
    public class Draw {
        public Draw(DateTime drawDate) {
            DrawDate = drawDate;
        }

        public decimal TotalPoolSize { get; private set; }

        public void AddTicket(int playerId, int[] numbers, decimal amount) {
            TotalPoolSize += amount;
            tickets.Add(MakeId(numbers), new Ticket(playerId, DrawDate, amount, numbers));
        }

        public Ticket GetTicket(int[] numbers) {
            return tickets[MakeId(numbers)];
        }

        public Dictionary<int, List<Ticket>> SplitTicketsIntoCategories(int[] numbers) {
            var result = new Dictionary<int, List<Ticket>>();
            for (var matches = 0; matches <= numbers.Length; matches++) {
                result.Add(matches, new List<Ticket>());
            }
            foreach (var ticket in tickets.Values) {
                result[ticket.CountMatches(numbers)].Add(ticket);
            }
            return result;
        }

        public IEnumerable<Ticket> GetTickets(int playerId) {
            return tickets.Values.Where(ticket => ticket.PlayerId == playerId);
        }

        static string MakeId(int[] numbers) {
            Array.Sort(numbers);
            return numbers.Aggregate(new StringBuilder(), (s, i) => s.Append(i).Append("-"), s => s.ToString());
        }

        public DateTime DrawDate { get; private set; }

        readonly Dictionary<string, Ticket> tickets = new Dictionary<string, Ticket>();
    }
}
