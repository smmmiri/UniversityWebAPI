namespace Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AcademyDbContext _academy;

        public GenericRepository(AcademyDbContext academy)
        {
            _academy = academy;
        }

        public void Add(T obj)
        {
            _academy.Set<T>().Add(obj);
        }

        public void Delete(object id)
        {
            var result = _academy.Set<T>().Find(id);
            _academy.Set<T>().Remove(result);
        }

        public T GetById(object id)
        {
            return _academy.Set<T>().Find(id);
        }

        public void Update(T obj)
        {
            _academy.Set<T>().Update(obj);
        }
    }
}
