namespace APIBiblioteca.DTO
{
  public class BookDTO
  {
    public int Id { get; set; }

    public string? Title { get; set; }

    public bool ToOffer { get; set; }

    public string PublicationDate { get; set; }


    public string? NameAuthor { get; set; }


    public string? NameGenres { get; set; }

    public HashSet<CommentListDTO>  Comments{ get; set; } = new HashSet<CommentListDTO>();
  }
}
