using System;
using System.Collections.Generic;
using fit;
using fitlibrary;

namespace Tristan.Test {
    public class ViewTickets: DoFixture {
        public ViewTickets() {
            var players = new Players();
            var draws = new Draws();
            playerService = new PlayerService(players, draws);
            drawService = new DrawService(players, draws);
        }

        public void DrawOnIsOpen(DateTime drawDate) {
            drawService.CreateDraw(drawDate);
        }
/*
        public Fixture CreateAccounts() {
            return new CreateAccounts(playerService);
        }

        public Fixture PurchaseTickets() {
            return new PurchaseTicketsForDraw(playerService);
        }
*/
        public IEnumerable<Ticket> PlayerViewsTickets(string name) {
            return playerService.ViewTicketsForPlayer(name);
        }

        public IEnumerable<Ticket> PlayerViewsOpenTickets(string name) {
            return playerService.ViewOpenTicketsForPlayer(name);
        }

        public IEnumerable<Ticket> PlayerViewsTicketsForDrawOn(string name, DateTime drawDate) {
            return playerService.ViewTicketsForPlayer(name, drawDate);
        }

        public void DrawResultsAre(DateTime drawDate, int[] numbers) {
            drawService.SettleDraw(drawDate, numbers);
        }

        readonly DrawService drawService;
        readonly PlayerService playerService;
    }
}
