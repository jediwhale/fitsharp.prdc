using fit;

namespace Tristan.Test {
    public class RegisterPlayers: ColumnFixture {
        public override void Reset() {
            registration = new PlayerRegistration();
            SetSystemUnderTest(registration);
        }

        public override void Execute() {
            SetSystemUnderTest(Processor.CallStack.GetSystemUnderTest<PlayerService>().Register(registration));
        }

        PlayerRegistration registration;
    }
}
