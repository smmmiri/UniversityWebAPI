namespace Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(object id);
        void Add(T obj);
        void Update(T obj);
        void Delete(object id);
    }
}
