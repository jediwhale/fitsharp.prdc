using System;

namespace Tristan {
    public class Player {
        public Player(PlayerRegistration registration) {
            Balance = 0M;
            UserName = registration.UserName;
            Password = registration.Password;
            Name = registration.Name;
            Address = registration.Address;
            City = registration.City;
            Country = registration.Country;
            PostCode = registration.PostCode;
            Verification = new Random().Next().ToString();
        }

        public bool IsVerified(string password, string verification) {
            var verified = Password == password && 
                (Verification == verification || Verification.Length == 0);
            if (verified) Verification = string.Empty;
            return verified;
        }

        public void AdjustBalance(decimal amount) {
            var newBalance = Balance + amount;
            if (newBalance < 0) throw new InsufficientFundsException();
            Balance += amount;
        }

        string Password { get; set; }

        public string Verification{ get; private set; }
        public int PlayerId { get; set; }
        public decimal Balance { get; private set; }
        public string UserName { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string PostCode { get; private set; }
        public string Country { get; private set; }

    }
}
