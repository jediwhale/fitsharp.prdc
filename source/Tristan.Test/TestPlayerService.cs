using System;
using fitSharp.Machine.Model;

namespace Tristan.Test {
    public class TestPlayerService: DomainAdapter {
        public TestPlayerService() {
            var players = new Players();
            Draws = new Draws();
            PlayerService = new PlayerService(players, Draws);
            drawService = new DrawService(players, Draws);
        }

        public object SystemUnderTest { get { return PlayerService; } }

        public void CreateDraw(DateTime drawDate) {
            drawService.CreateDraw(drawDate);
        }

        readonly DrawService drawService;

        public PlayerService PlayerService { get; private set; }
        public Draws Draws { get; private set; }
    }
}
