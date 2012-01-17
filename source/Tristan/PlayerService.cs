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
            return players.Values.Where(player => player.UserName == userName).FirstOrDefault();
        }

        public int LoginPlayer(string username, string password) {
            var player = GetPlayer(username);
            if (player == null || !player.HasPassword(password)) throw new InvalidLogInException();
            return player.PlayerId;
        }

        public void DepositWithCard(int playerId, string card, string expiry, decimal amount) {
            players[playerId].AdjustBalance(amount);
        }

        public Response Register(PlayerRegistration registration) {
            if (players.Values.Any(player => player.UserName == registration.UserName)) {
                return new Response(false, "Duplicate user name");
            }

            var newPlayer = new Player(nextId++, registration);
            players.Add(newPlayer.PlayerId, newPlayer);
            return new Response(true, "Player registered");
        }

        public IEnumerable<Player> GetPlayers(string userName) {
            return players.Values.Where(player => player.UserName == userName);
        }

        public Response Login(string username, string password) {
            var loggedIn = GetPlayers(username).ForFirst(player => player.HasPassword(password), () => false);
            return loggedIn
                ? new Response(true, "Player logged in")
                : new Response(false, "Invalid log in");
        }

        static int nextId = 1;

        readonly Dictionary<int, Player> players = new Dictionary<int,Player>();
    }
}
