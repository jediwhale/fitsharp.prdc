using fit;

namespace Tristan.Test {
    public class CheckStoredDetailsFor: ColumnFixture {
        public override object GetTargetObject() {
            var newId = (int)Recall(Args[0]);
            return SetUpTestEnvironment.PlayerManager.GetPlayer(newId);
        }
    }
}
