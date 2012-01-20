using System;
using fitSharp.Machine.Model;

namespace Tristan.Test {
    public class TestPlayerService: DomainAdapter {
        public TestPlayerService() {
            var players = new Players();
            draws = new Draws();
            playerService = new PlayerService(players, draws);
            drawService = new DrawService(players, draws);
        }

        public object SystemUnderTest { get { return playerService; } }

        public void CreateDraw(DateTime drawDate) {
            drawService.CreateDraw(drawDate);
        }

        public decimal PoolValueForDraw(DateTime drawDate) {
            return draws[drawDate].TotalPoolSize;
        }

        readonly Draws draws;
        readonly DrawService drawService;
        readonly PlayerService playerService;
    }
}
