using System;
using System.Collections.Generic;
using fitSharp.Machine.Model;

namespace Tristan.Test {
    public class TestPlayerService: DomainAdapter {
        public TestPlayerService(PlayerService playerService) {
            this.playerService = playerService;
        }

        public object SystemUnderTest { get { return playerService; } }

        public IEnumerable<Ticket> ViewTicketsForPlayerInDraw(string name, DateTime drawDate) {
            return playerService.ViewTicketsForPlayer(name, drawDate);
        }

        readonly PlayerService playerService;
    }
}
