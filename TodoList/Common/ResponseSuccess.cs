namespace TodoList.Common
{
    public class ResponseSuccess : IResponse
    {
        public object Value { get; set; }
        public int Status { get; set; }

        public ResponseSuccess(object value, int status)
        {
            Value = value;
            Status = status;
        }
    }
}
