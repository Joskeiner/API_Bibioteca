using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIBiblioteca.Models;
using APIBiblioteca.DAL.Interface;
using APIBiblioteca.DTO;
using AutoMapper;
namespace APIBiblioteca.Controllers
{
  [Route("api/author")]
  [ApiController]
  public class AuthorController : ControllerBase
  {
    private readonly IGenericRepository<Author> _repository;
    private readonly IMapper _mapper;
    public AuthorController(IGenericRepository<Author> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAll()
    {
      var author = await _repository.GetAll();
      var authorDTO = _mapper.Map<IEnumerable<AuthorDTO>>(author);
      return Ok(authorDTO);
    }
    [HttpGet("{id}", Name = "GetAuthor")]
    public async Task<ActionResult<AuthorDTO>> GetOne(int id)
    {
      var author = await _repository.GetOne(id);
      if (author == null)
      {
        return NotFound();
      }
      var authorDTO = _mapper.Map<AuthorDTO>(author);
      return Ok(authorDTO);
    }

    [HttpPost]
    public async Task<ActionResult<AuthorCreateDTO>> Create(AuthorCreateDTO entity)
    {
      var author = _mapper.Map<Author>(entity);

      var result = await _repository.Insert(author);
      if (!result)
      {
        return NotFound();
      }
      var dto = _mapper.Map<AuthorCreateDTO>(entity);
      return new CreatedAtRouteResult("GetAuthor", new { id = author.Id }, dto);
    }
  }
}
