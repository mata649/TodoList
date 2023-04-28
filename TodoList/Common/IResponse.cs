namespace TodoList.Common
{
    public interface IResponse
    {
        public object Value { get; set; }
        public int Status { get; set; }
    }
}
