using System;
using System.Collections.Generic;
using fit;
using fitlibrary;

namespace Tristan.Test {
    public class ViewTickets: DoFixture {
        public ViewTickets() {
            playerService = new PlayerService();
            drawService = new DrawService(playerService);
        }

        public void DrawOnIsOpen(DateTime drawDate) {
            drawService.CreateDraw(drawDate);
        }

        public Fixture CreateAccounts() {
            return new CreateAccounts(playerService);
        }

        public Fixture PurchaseTickets() {
            return new PurchaseTickets(playerService, drawService);
        }

        public IEnumerable<Ticket> PlayerViewsTickets(string name) {
            return drawService.GetTickets(playerService.GetPlayer(name).PlayerId);
        }

        public IEnumerable<Ticket> PlayerViewsOpenTickets(string name) {
            return drawService.GetOpenTickets(playerService.GetPlayer(name).PlayerId);
        }

        public IEnumerable<Ticket> PlayerViewsTicketsForDrawOn(string name, DateTime drawDate) {
            return drawService.GetTickets(playerService.GetPlayer(name).PlayerId, drawDate);
        }

        public void DrawResultsAre(DateTime drawDate, int[] numbers) {
            drawService.SettleDraw(drawDate, numbers);
        }

        readonly DrawService drawService;
        readonly PlayerService playerService;
    }
}
