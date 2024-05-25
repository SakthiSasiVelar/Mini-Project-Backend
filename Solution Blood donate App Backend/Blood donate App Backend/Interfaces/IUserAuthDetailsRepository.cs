namespace Blood_donate_App_Backend.Interfaces
{
    public interface IUserAuthDetailsRepository<K,T> where T : class
    {
        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
        public Task<T> Delete(K id);
        public Task<T> GetById(K id);
        public Task<T> GetByEmail(string email);
        public Task<IEnumerable<T>> GetAll();
    }
}
