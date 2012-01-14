namespace Tristan {
    public class Player {
        public Player(int playerId, PlayerRegistration registration) {
            PlayerId = playerId;
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

        public int PlayerId { get; private set; }
        public decimal Balance { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string PostCode { get; private set; }
        public string Country { get; private set; }

    }
}
