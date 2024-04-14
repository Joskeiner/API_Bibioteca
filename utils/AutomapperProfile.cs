using APIBiblioteca.DTO;
using APIBiblioteca.Models;
using AutoMapper;
namespace APIBiblioteca.utils
{
  public class AutomapperProfile : Profile
  {
    public AutomapperProfile()
    {

      CreateMap<AuthorCreateDTO, Author>()
        .ForMember(p => p.PublicationDate,
            opt => opt.MapFrom(p => DateTime.Parse(p.PublicationDate))).ReverseMap();

      CreateMap<Author, AuthorDTO>()
        .ForMember(p => p.PublicationDate,
            opt => opt.MapFrom(p => p.PublicationDate.ToString("dd/MM/yyyy")));
      CreateMap<Genre, GenreDTO>().ReverseMap();
      CreateMap<CreateGenreDTO, Genre>().ReverseMap();
      CreateMap<Book, BookDTO>()
        .ForMember(d => d.NameAuthor, o => o.MapFrom(opt => opt.Author.Name))
        .ForMember(d => d.NameGenres, p => p.MapFrom(opt => opt.Genres.Name))
        .ForMember(d => d.PublicationDate, p => p.MapFrom(opt => opt.PublicationDate.ToString("dd/MM/yyyy")));
      
      CreateMap<CreateBookDTO, Book>()
      .ForMember(d => d.Id, p => p.Ignore())
      .ForMember(d => d.Author, p => p.Ignore())
      .ForMember(d => d.Genres, p=> p.Ignore());

      CreateMap<Comment , CommentDTO>().ReverseMap();
      CreateMap<CommentListDTO, Comment>().ReverseMap();
    }
  
  }
}
