using System.Collections.Generic;
using System.Linq;

namespace Tristan {
    public class Players {
        public void Add(Player newPlayer) {
            newPlayer.PlayerId = nextId++;
            players.Add(newPlayer.PlayerId, newPlayer);
        }

        public IEnumerable<Player> GetPlayers(string userName) {
            return players.Values.Where(player => player.UserName == userName);
        }

        public Player this[int playerId] {
            get { return players[playerId]; }
        }

        static int nextId = 1;

        readonly Dictionary<int, Player> players = new Dictionary<int,Player>();
    }
}
