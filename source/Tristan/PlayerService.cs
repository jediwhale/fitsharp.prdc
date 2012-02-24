using System;
using System.Collections.Generic;
using System.Linq;

namespace Tristan {
    public class PlayerService {
        public PlayerService(Players players, Draws draws) {
            this.players = players;
            this.draws = draws;
        }

        public Response Register(PlayerRegistration registration) {
            if (players.GetPlayers(registration.UserName).Any()) {
                return new Response(false, "Duplicate user name");
            }

            var newPlayer = new Player(registration);
            players.Add(newPlayer);
            return new Response(true, "Player registered");
        }

        public Player PlayerWithUserName(string userName) {
            return players.GetPlayers(userName).FirstOrDefault();
        }

        public Response Login(string username, string password) {
            var loggedIn = players.GetPlayers(username).ForFirst(player => player.HasPassword(password), () => false);
            return loggedIn
                ? new Response(true, "Player logged in")
                : new Response(false, "Invalid log in");
        }

        public void DepositWithCard(string userName, string card, string expiry, decimal amount) {
            var playerId = PlayerWithUserName(userName).PlayerId;
            players[playerId].AdjustBalance(amount);
        }

        public void PurchaseTicket(DateTime drawDate, string userName, int[] numbers, int count) {
            var playerId = PlayerWithUserName(userName).PlayerId;
            var player = players[playerId];
            var cost = Ticket.TicketCost * count;
            player.AdjustBalance(-cost);
            draws[drawDate].AddTicket(playerId, numbers, cost);
        }

        public decimal AccountBalanceFor(string userName) {
            return PlayerWithUserName(userName).Balance;
        }

        public IEnumerable<Ticket> Tickets(string userName, DateTime drawDate, int[] numbers) {
            var ticket = draws[drawDate].GetTicket(numbers);
            return ticket != null && ticket.PlayerId == PlayerWithUserName(userName).PlayerId
                       ? new List<Ticket> {ticket}
                       : new List<Ticket>();
        }

        public IEnumerable<Ticket> ViewTicketsForPlayer(string userName) {
            return draws.GetTickets(PlayerWithUserName(userName).PlayerId);
        }

        public IEnumerable<Ticket> ViewOpenTicketsForPlayer(string userName) {
            return ViewTicketsForPlayer(userName).Where(ticket => ticket.IsOpen);
        }

        public IEnumerable<Ticket> ViewTicketsForPlayer(string userName, DateTime drawDate) {
            return draws[drawDate].GetTickets(PlayerWithUserName(userName).PlayerId);
        }

        readonly Players players;
        readonly Draws draws;
    }
}
