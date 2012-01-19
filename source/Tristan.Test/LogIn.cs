using fit;
using fitSharp.Fit.Engine;

namespace Tristan.Test {
    public class LogIn: ColumnFixture {
        public string UserName;
        public string Password;

        public override void Execute() {
            var playerService = Processor.GetSystemUnderTest<PlayerService>();
            SetSystemUnderTest(playerService.Login(UserName, Password));
        }
    }
}
