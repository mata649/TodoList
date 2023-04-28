namespace TodoList.Common
{
    public class ResponseFailure : IResponse
    {
        private class Error
        {
            public string Message { get; set; } = string.Empty;
        }

        public object Value { get; set; }
        public int Status { get; set; }

        public ResponseFailure(string message, int status)
        {
            Value = new Error() { Message = message };
            Status = status;
        }
    }
}
