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
    }
  }
}
