using fit;

namespace Tristan.Test {
    public class PlayerRegisters: ColumnFixture {
        public override void Reset() {
            registration = new PlayerRegistrationInfo();
            SetSystemUnderTest(registration);
        }

        public int NewPlayerId() {
            return SetUpTestEnvironment.PlayerService.RegisterPlayer(registration);
        }

        PlayerRegistrationInfo registration;
    }
}
