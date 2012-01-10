using fit;

namespace Tristan.Test {
    public class CheckLogin: ColumnFixture {
        public string UserName;
        public string Password;

        public int LoggedInAsPlayerId() {
            return SetUpTestEnvironment.PlayerManager.Login(UserName, Password);
        }
    }
}
