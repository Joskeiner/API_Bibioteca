using APIBiblioteca.Models;

namespace APIBiblioteca.DAL.Interface{
    public interface IBookRepository : IGenericRepository<Book>
    {
        public Task<Book> GetBooksWithAll( int id);
    }
}