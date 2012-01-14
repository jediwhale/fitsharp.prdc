using fit;

namespace Tristan.Test {
    public class PlayerRegisters: ColumnFixture {
        public override void Reset() {
            registration = new PlayerRegistration();
            SetSystemUnderTest(registration);
        }

        public int NewPlayerId() {
            return SetUpTestEnvironment.PlayerService.RegisterPlayer(registration);
        }

        PlayerRegistration registration;
    }
}
