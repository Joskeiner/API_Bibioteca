
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIBiblioteca.Models;
using APIBiblioteca.DAL.Interface;
using APIBiblioteca.DTO;
using AutoMapper;
namespace APIBiblioteca.Controllers
{
  [Route("api/books")]
  [ApiController]
  public class BookController : ControllerBase
  {
    private readonly IGenericRepository<Book> _repository;
    private readonly IMapper _mapper;
    public BookController(IGenericRepository<Book> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }
    [HttpGet("{id}", Name = "GetBook")]
    public async Task<ActionResult<BookDTO>> GetOne(int id)
    {
      var book = await _repository.GetOne(id);
      if (book == null)
      {
        return NotFound();
      }
      var bookDTO = _mapper.Map<BookDTO>(book);
      return Ok(bookDTO);
    }

    [HttpPost]
    public async Task<ActionResult<CreateBookDTO>> Create(CreateBookDTO entity)
    {
      var book = _mapper.Map<Book>(entity);

      var result = await _repository.Insert(book);
      if (!result)
      {
        return NotFound();
      }
      var dto = _mapper.Map<CreateBookDTO>(entity);
      return new CreatedAtRouteResult("GetBook", new { id = book.Id }, dto);
    }
  }
}
