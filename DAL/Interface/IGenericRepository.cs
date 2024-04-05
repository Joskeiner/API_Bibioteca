namespace APIBiblioteca.DAL.Interface
{
  public interface IGenericRepository<T> where T : class
  {
    Task<IEnumerable<T>> GetAll();
    Task<T> GetOne(int id);
    Task<bool> Insert(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(int id);
  }

}
