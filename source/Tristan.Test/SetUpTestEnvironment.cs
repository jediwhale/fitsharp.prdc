using System;
using System.Collections.Generic;

namespace Tristan.Test {
    public class SetUpTestEnvironment {
        public SetUpTestEnvironment() {
            players = new Players();
            PlayerService = new PlayerService(players);
            DrawService = new DrawService(players);
        }

        public IEnumerable<Player> ShowPlayer(int playerId) {
            return new List<Player> { players[playerId] };
        }

        public void CreateDraw(DateTime drawDate) {
            DrawService.CreateDraw(drawDate);
        }

        readonly Players players;

        public static PlayerService PlayerService;
        public static DrawService DrawService;
    }
}
