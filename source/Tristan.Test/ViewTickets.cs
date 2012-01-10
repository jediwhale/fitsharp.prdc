using System;
using System.Collections.Generic;
using fit;
using fitlibrary;

namespace Tristan.Test {
    public class ViewTickets: DoFixture {
        public ViewTickets() {
            playerManager = new PlayerManager();
            drawManager = new DrawManager(playerManager);
        }

        public void DrawOnIsOpen(DateTime drawDate) {
            drawManager.CreateDraw(drawDate);
        }

        public Fixture CreateAccounts() {
            return new CreateAccounts(playerManager);
        }

        public Fixture PurchaseTickets() {
            return new PurchaseTickets(playerManager, drawManager);
        }

        public IEnumerable<Ticket> PlayerViewsTickets(string name) {
            return drawManager.GetTickets(playerManager.GetPlayer(name).PlayerId);
        }

        public IEnumerable<Ticket> PlayerViewsOpenTickets(string name) {
            return drawManager.GetOpenTickets(playerManager.GetPlayer(name).PlayerId);
        }

        public IEnumerable<Ticket> PlayerViewsTicketsForDrawOn(string name, DateTime drawDate) {
            return drawManager.GetTickets(playerManager.GetPlayer(name).PlayerId, drawDate);
        }

        public void DrawResultsAre(DateTime drawDate, int[] numbers) {
            drawManager.SettleDraw(drawDate, numbers);
        }

        readonly DrawManager drawManager;
        readonly PlayerManager playerManager;
    }
}
