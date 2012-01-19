using System;
using System.Collections.Generic;
using System.Linq;

namespace Tristan {
    public class PlayerService {
        public PlayerService(Players players, Draws draws) {
            this.players = players;
            this.draws = draws;
        }

        public int RegisterPlayer(PlayerRegistration registration) {
            if (players.GetPlayers(registration.UserName).Any()) throw new DuplicateUserNameException();

            var newPlayer = new Player(registration);
            players.Add(newPlayer);
            return newPlayer.PlayerId;
        }

        public Player GetPlayer(int playerId) {
            return players[playerId];
        }

        public Player PlayerWithUserName(string userName) {
            return players.GetPlayers(userName).FirstOrDefault();
        }

        public int LoginPlayer(string username, string password) {
            var player = PlayerWithUserName(username);
            if (player == null || !player.HasPassword(password)) throw new InvalidLogInException();
            return player.PlayerId;
        }

        public void DepositWithCard(int playerId, string card, string expiry, decimal amount) {
            players[playerId].AdjustBalance(amount);
        }

        public Response Register(PlayerRegistration registration) {
            if (players.GetPlayers(registration.UserName).Any()) {
                return new Response(false, "Duplicate user name");
            }

            var newPlayer = new Player(registration);
            players.Add(newPlayer);
            return new Response(true, "Player registered");
        }

        public Response Login(string username, string password) {
            var loggedIn = players.GetPlayers(username).ForFirst(player => player.HasPassword(password), () => false);
            return loggedIn
                ? new Response(true, "Player logged in")
                : new Response(false, "Invalid log in");
        }

        public void PurchaseTicket(DateTime drawDate, int playerId, int[] numbers, int count) {
            var player = players[playerId];
            var cost = Ticket.TicketCost * count;
            player.AdjustBalance(-cost);
            draws[drawDate].AddTicket(playerId, numbers, cost);
        }

        public decimal PoolValueForDraw(DateTime drawDate) {
            return draws[drawDate].TotalPoolSize;
        }

        public IEnumerable<Ticket> Tickets(string userName, DateTime drawDate, int[] numbers) {
            var ticket = draws[drawDate].GetTicket(numbers);
            return ticket != null && ticket.PlayerId == PlayerWithUserName(userName).PlayerId
                       ? new List<Ticket> {ticket}
                       : new List<Ticket>();
        }

        readonly Players players;
        readonly Draws draws;
    }
}
