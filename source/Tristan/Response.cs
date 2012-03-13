namespace Tristan {
    public class Response {
        public Response(bool succeeded, string message): this(succeeded, message, string.Empty) {}

        public Response(bool succeeded, string message, string verification) {
            Succeeded = succeeded;
            Message = message;
            Verification = verification;
        }

        public bool Succeeded { get; private set; }
        public string Message { get; private set; }
        public string Verification { get; private set; }
    }
}
