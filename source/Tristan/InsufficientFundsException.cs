using System;

namespace Tristan {
    public class InsufficientFundsException: ApplicationException {
        public InsufficientFundsException() : base("Insufficient funds") {}
    }
}
