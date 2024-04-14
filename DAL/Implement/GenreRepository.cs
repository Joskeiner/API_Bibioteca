using APIBiblioteca.DAL.DataContext;
using APIBiblioteca.DAL.Interface;
using APIBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace APIBiblioteca.DAL.Implement
{
    public class GenreRepository : GenericRepository<Genre> , IGenreRepository
    {

    private readonly ApplicationDbContext _context;
        public GenreRepository( ApplicationDbContext context) :base(context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Genre>> GetAllWithBooks()
        {
          return await _context.Genres.Include(p => p.Books)
                                             .ThenInclude(p => p.Author)
                                             .ToListAsync();
        }
    }
}