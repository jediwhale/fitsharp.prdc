namespace Tristan {
    public class Response {
        public Response(bool succeeded, string message) {
            Succeeded = succeeded;
            Message = message;
        }

        public bool Succeeded { get; private set; }
        public string Message { get; private set; }
    }
}
