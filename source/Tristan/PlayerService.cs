using System.Collections.Generic;
using System.Linq;

namespace Tristan {
    public class PlayerService {
        public int RegisterPlayer(PlayerRegistration registration) {
            if (players.Values.Any(player => player.UserName == registration.UserName)) {
                throw new DuplicateUserNameException();
            }

            var newPlayer = new Player(nextId++, registration);
            players.Add(newPlayer.PlayerId, newPlayer);
            return newPlayer.PlayerId;
        }

        public Player GetPlayer(int playerId) {
            return players[playerId];
        }

        public Player GetPlayer(string userName) {
            return players.Values.Where(player => player.UserName == userName).First();
        }

        public int Login(string username, string password) {
            var loggedInPlayer = players.Values
                    .Where(player => player.UserName == username && player.Password == password)
                    .FirstOrDefault();
            if (loggedInPlayer == null) throw new InvalidLogInException();
            return loggedInPlayer.PlayerId;
        }

        public void DepositWithCard(int playerId, string card, string expiry, decimal amount) {
            players[playerId].AdjustBalance(amount);
        }

        static int nextId = 1;

        readonly Dictionary<int, Player> players = new Dictionary<int,Player>();
    }
}
