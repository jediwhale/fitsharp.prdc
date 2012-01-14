using System;
using System.Collections.Generic;

namespace Tristan.Test {
    public class SetUpTestEnvironment {
        public SetUpTestEnvironment() {
            PlayerService = new PlayerService();
            DrawService = new DrawService(PlayerService);
        }

        public IEnumerable<Player> ShowPlayer(int playerId) {
            return new List<Player> { PlayerService.GetPlayer(playerId) };
        }

        public void CreateDraw(DateTime drawDate) {
            DrawService.CreateDraw(drawDate);
        }

        public static PlayerService PlayerService;
        public static DrawService DrawService;
    }
}
