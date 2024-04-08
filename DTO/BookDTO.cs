namespace APIBiblioteca.DTO
{
  public class BookDTO
  {
    public int Id { get; set; }

    public string? Title { get; set; }

    public bool ToOffer { get; set; }

    public DateTime PublicationDate { get; set; }


    public string? NameAuthor { get; set; }


    public string? NameGenres { get; set; }

    public HashSet<CommmentListDTO> Comentarios { get; set; } = new HashSet<CommmentListDTO>();
  }
}
