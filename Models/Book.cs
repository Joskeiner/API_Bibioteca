
namespace APIBiblioteca.Models
{
  public class Book
  {
    public int Id { get; set; }

    public string? Title { get; set; }

    public bool ToOffer { get; set; }

    public DateTime PublicationDate { get; set; }

    public int AuthorId { get; set; }

    public Author? Author { get; set; }

    public int GenreId { get; set; }

    public Genre? Genres { get; set; }

    public HashSet<Comment>  Comments { get; set; } = new HashSet<Comment>();



  }

}
