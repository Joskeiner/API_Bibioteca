using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIBiblioteca.Models;
using APIBiblioteca.DAL.Interface;
using APIBiblioteca.DTO;
using AutoMapper;
namespace APIBiblioteca.Controllers
{
  [Route("api/genre")]
  [ApiController]
  public class GenreController : ControllerBase
  {
    private readonly IGenericRepository<Genre> _repository;
    private readonly IMapper _mapper;
    public GenreController(IGenericRepository<Genre> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GenreDTO>>> GetAll()
    {
      var genres = await _repository.GetAll();
      var genresDTO = _mapper.Map<IEnumerable<GenreDTO>>(genres);
      return Ok(genresDTO);
    }
    [HttpGet("{id}", Name = "GetGenre")]
    public async Task<ActionResult<GenreDTO>> GetOne(int id)
    {
      var genres = await _repository.GetOne(id);
      if (genres == null)
      {
        return NotFound();
      }
      var genreDTO = _mapper.Map<GenreDTO>(genres);
      return Ok(genreDTO);
    }

    [HttpPost]
    public async Task<ActionResult<CreateGenreDTO>> Create([FromBody] CreateGenreDTO entity)
    {
      var genre = _mapper.Map<Genre>(entity);

      var result = await _repository.Insert(genre);
      if (!result)
      {
        return NotFound();
      }
      var dto = _mapper.Map<AuthorCreateDTO>(entity);
      return Ok(dto);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, CreateGenreDTO entity)
    {
      var searchGenre = await _repository.GetOne(id);
      if (searchGenre == null)
      {
        return NotFound();
      }

      _mapper.Map(entity, searchGenre);
      var result = await _repository.Update(searchGenre);
      if (result)
      {
        return NoContent();
      }
      return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
      var searchAuthor = await _repository.GetOne(id);
      if (searchAuthor == null)
      {
        return NotFound();
      }
      var result = await _repository.Delete(id);
      if (result)
      {
        return NoContent();
      }
      return BadRequest();
    }
  }
}

