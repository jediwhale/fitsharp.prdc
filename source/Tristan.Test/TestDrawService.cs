using fitSharp.Machine.Model;

namespace Tristan.Test {
    public class TestDrawService: DomainAdapter {
        public TestDrawService(Players players) {
            DrawService = new DrawService(players, new Draws());
        }

        public object SystemUnderTest { get { return DrawService; } }

        public DrawService DrawService { get; private set; }
    }
}
