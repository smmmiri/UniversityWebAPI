namespace Repository.Interfaces
{
    public interface ILogoutRepository
    {
        void AddToBlackList(string token);
    }
}
