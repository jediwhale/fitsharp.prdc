namespace Tristan {
    public class PlayerInfo {
        public PlayerInfo(PlayerRegistrationInfo registration) {
            PlayerId = nextId++;
            Balance = 0M;
            UserName = registration.UserName;
            Password = registration.Password;
            Name = registration.Name;
            Address = registration.Address;
            City = registration.City;
            Country = registration.Country;
            PostCode = registration.PostCode;
        }

        public void AdjustBalance(decimal amount) {
            var newBalance = Balance + amount;
            if (newBalance < 0) throw new InsufficientFundsException();
            Balance += amount;
        }

        public int PlayerId;
        public decimal Balance { get; private set; }
        public string UserName;
        public string Password;
        public string Name;
        public string Address;
        public string City;
        public string PostCode;
        public string Country;

        static int nextId = 1;
    }
}
