using fit;

namespace Tristan.Test {
    public class RegisterPlayers: ColumnFixture {
        public RegisterPlayers(PlayerService playerService) {
            this.playerService = playerService;
        }

        public override void Reset() {
            registration = new PlayerRegistration();
            SetSystemUnderTest(registration);
        }

        public override void Execute() {
            SetSystemUnderTest(playerService.Register(registration));
        }

        PlayerRegistration registration;
        readonly PlayerService playerService;
    }
}
