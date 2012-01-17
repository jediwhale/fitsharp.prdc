using fit;
using fitSharp.Machine.Model;

namespace Tristan.Test {
    public class TestPlayerService: DomainAdapter {
        public TestPlayerService() {
            var players = new Players();
            PlayerService = new PlayerService(players);
            TestDrawService = new TestDrawService(players);
        }

        public object SystemUnderTest { get { return PlayerService; } }

        public Fixture PurchaseTicket() {
            return new PurchaseTicket(this);
        }

        public TestDrawService TestDrawService { get; private set; }
        public DrawService DrawService { get { return TestDrawService.DrawService; } }

        public PlayerService PlayerService { get; private set; }
    }
}
