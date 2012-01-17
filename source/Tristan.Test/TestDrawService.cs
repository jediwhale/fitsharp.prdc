using fitSharp.Machine.Model;

namespace Tristan.Test {
    public class TestDrawService: DomainAdapter {
        public TestDrawService(PlayerService playerService) {
            DrawService = new DrawService(playerService);
        }

        public object SystemUnderTest { get { return DrawService; } }

        public DrawService DrawService { get; private set; }
    }
}
