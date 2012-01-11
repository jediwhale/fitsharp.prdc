using fit;

namespace Tristan.Test {
    public class CheckStoredDetailsFor: ColumnFixture {
        public override object GetTargetObject() {
            var newId = GetArgumentInput<int>(0);
            return SetUpTestEnvironment.PlayerService.GetPlayer(newId);
        }
    }
}
