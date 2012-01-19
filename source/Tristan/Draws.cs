using System;
using System.Collections.Generic;
using System.Linq;

namespace Tristan {
    public class Draws {
        public IEnumerable<Ticket> GetTickets(int playerId) {
            return draws.Values.SelectMany(draw => draw.GetTickets(playerId));
        }

        public Draw this[DateTime drawDate] {
            get { return draws[drawDate]; }
        }

        public void Add(Draw newDraw) {
            draws.Add(newDraw.DrawDate, newDraw);
        }

        readonly Dictionary<DateTime, Draw> draws = new Dictionary<DateTime,Draw>();
    }
}
