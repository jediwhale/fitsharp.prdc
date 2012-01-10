using System;

namespace Tristan {
    public class DuplicateUserNameException: ApplicationException {
        public DuplicateUserNameException(): base("Duplicate user name") {}
    }
}
