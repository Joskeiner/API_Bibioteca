using APIBiblioteca.Models;

namespace APIBiblioteca.DAL.Interface{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        public Task<IEnumerable<Genre>> GetAllWithBooks();
    }
}