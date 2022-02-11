namespace DataLayer.IRepositories
{
    public interface IRepository<T>
    {
        public void Create(T _object);

        public void Update(T _object);

        public IEnumerable<T> GetAll();

        public T GetById(int id);

        public void Delete(T _object);
    }
}
