namespace APIBiblioteca.Models
{
  public class Author
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime PublicationDate { get; set; }
    public HashSet<Book> Books { get; set; } = new HashSet<Book>();
  }

}
