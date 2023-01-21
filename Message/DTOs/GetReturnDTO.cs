namespace Message.DTOs
{
    public class GetReturnDTO<T>
    {
        public IEnumerable<T> List { get; set; }

        public int Count { get; set; }
    }
}
