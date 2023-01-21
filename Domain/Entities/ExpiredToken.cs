namespace Domain.Entities
{
    public class ExpiredToken
    {
        public ExpiredToken()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Token { get; set; }
    }
}
