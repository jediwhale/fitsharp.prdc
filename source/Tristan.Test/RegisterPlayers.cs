using fit;
using fitSharp.Fit.Engine;

namespace Tristan.Test {
    public class RegisterPlayers: ColumnFixture {
        public override void Reset() {
            registration = new PlayerRegistration();
            SetSystemUnderTest(registration);
        }

        public override void Execute() {
            var playerService = Processor.GetSystemUnderTest<PlayerService>();
            SetSystemUnderTest(playerService.Register(registration));
        }

        PlayerRegistration registration;
    }
}
