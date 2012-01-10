using fit;

namespace Tristan.Test {
    public class PlayerRegisters: ColumnFixture {
        public override object GetTargetObject() {
            return target;
        }

        readonly TargetPlayerRegistrationInfo target = new TargetPlayerRegistrationInfo();

        class TargetPlayerRegistrationInfo: PlayerRegistrationInfo {
            public int NewPlayerId() {
                return SetUpTestEnvironment.PlayerManager.RegisterPlayer(this);
            }
        }
    }
}
