using APIBiblioteca.Models;
namespace APIBiblioteca.DTO
{
  public class GenreDTO
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public HashSet<BookDTO> Books { get; set; } = new HashSet<BookDTO>();
  }
}
