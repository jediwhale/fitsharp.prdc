using fit;
using fitSharp.Machine.Model;

namespace Tristan.Test {
    public class TestPlayerService: DomainAdapter {
        public TestPlayerService() {
            PlayerService = new PlayerService();
            TestDrawService = new TestDrawService(PlayerService);
        }

        public object SystemUnderTest { get { return PlayerService; } }

        public Fixture RegisterPlayers() {
            return new RegisterPlayers(PlayerService);
        }

        public Fixture LogIn() {
            return new LogIn(PlayerService);
        }

        public Fixture PurchaseTicket() {
            return new PurchaseTicket(this);
        }

        public TestDrawService TestDrawService { get; private set; }
        public DrawService DrawService { get { return TestDrawService.DrawService; } }

        public PlayerService PlayerService { get; private set; }
    }
}
