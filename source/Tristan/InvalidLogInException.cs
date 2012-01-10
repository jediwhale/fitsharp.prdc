using System;

namespace Tristan {
    public class InvalidLogInException: ApplicationException {
        public InvalidLogInException(): base("Invalid log in") {}
        
    }
}
