using System;
using fitlibrary;

namespace Tristan.Test {
    public class SetUpTestEnvironment: DoFixture {
        public SetUpTestEnvironment() {
            PlayerManager = new PlayerManager();
            DrawManager = new DrawManager(PlayerManager);
        }

        public void CreateDraw(DateTime drawDate) {
            DrawManager.CreateDraw(drawDate);
        }

        public static PlayerManager PlayerManager;
        public static DrawManager DrawManager;
    }
}
