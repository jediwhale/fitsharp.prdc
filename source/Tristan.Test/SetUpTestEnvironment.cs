using System;
using fitlibrary;

namespace Tristan.Test {
    public class SetUpTestEnvironment: DoFixture {
        public SetUpTestEnvironment() {
            PlayerService = new PlayerService();
            DrawService = new DrawService(PlayerService);
        }

        public void CreateDraw(DateTime drawDate) {
            DrawService.CreateDraw(drawDate);
        }

        public static PlayerService PlayerService;
        public static DrawService DrawService;
    }
}
