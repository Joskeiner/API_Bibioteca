using APIBiblioteca.DAL.DataContext;
using APIBiblioteca.DAL.Interface;
using APIBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace APIBiblioteca.DAL.Implement
{
    public class BookRepository : GenericRepository<Book> , IBookRepository
    {

    private readonly ApplicationDbContext _context;
        public BookRepository( ApplicationDbContext context) :base(context)
        {
            _context = context;

        }
        public async Task<Book> GetBooksWithAll( int id )
        {
            var query = await _context.Books.Include(a => a.Author)
                                            .Include(g => g.Genres)
                                            .Include(c => c.Comments)
                                            .FirstOrDefaultAsync(b => b.Id == id);
          return  query;
        }
    }
}