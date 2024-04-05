using APIBiblioteca.DAL.Interface;
using APIBiblioteca.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
namespace APIBiblioteca.DAL.Implement
{
  public class GenericRepository<T> : IGenericRepository<T> where T : class
  {
    private readonly ApplicationDbContext _context;
    public GenericRepository(ApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<IEnumerable<T>> GetAll()
    {
      return await _context.Set<T>().ToListAsync();

    }
    public async Task<T> GetOne(int id)
    {
      return await _context.Set<T>().FindAsync(id);

    }
    public async Task<bool> Insert(T entity)
    {
      bool result = false;
      _context.Set<T>().AddAsync(entity);
      result = await _context.SaveChangesAsync() > 0;
      return result;
    }
    public async Task<bool> Update(T entity)
    {
      bool result = false;
      _context.Set<T>().Update(entity);
      result = await _context.SaveChangesAsync() > 0;
      return result;
    }
    public async Task<bool> Delete(int id)
    {
      var entity = await GetOne(id);
      if (entity == null)
      {
        return false;
      }
      _context.Set<T>().Remove(entity);
      bool result = await _context.SaveChangesAsync() > 0;
      return result;

    }
  }
}
