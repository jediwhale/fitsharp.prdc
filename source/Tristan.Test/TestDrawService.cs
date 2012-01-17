using fitSharp.Machine.Model;

namespace Tristan.Test {
    public class TestDrawService: DomainAdapter {
        public TestDrawService(Players players) {
            DrawService = new DrawService(players);
        }

        public object SystemUnderTest { get { return DrawService; } }

        public DrawService DrawService { get; private set; }
    }
}
