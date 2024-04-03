
namespace APIBiblioteca.Models
{
  public class Comment
  {

    public int Id { get; set; }

    public string? Content { get; set; }

    public bool Recommend { get; set; }

    public int BookId { get; set; }

    public Book? Books { get; set; }

  }

}
