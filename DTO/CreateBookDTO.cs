namespace APIBiblioteca.DTO
{
  public class CreateBookDTO
  {
    public string? Title { get; set; }

    public bool ToOffer { get; set; }

    public string? PublicationDate { get; set; }
    public int AuthorId { get; set; }
    public int GenreId { get; set; }
  }
}
