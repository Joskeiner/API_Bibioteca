
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
    private readonly IBookRepository _bookRepository;
    public BookController(IGenericRepository<Book> repository, IMapper mapper, IBookRepository bookRepository)
    {
      _repository = repository;
      _mapper = mapper;
      _bookRepository = bookRepository;
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
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDTO>>> GetAll()
    {
      var book = await _repository.GetAll();
      var bookDtos = _mapper.Map<IEnumerable<BookDTO>>(book);
      return Ok(bookDtos);
    }
    [HttpGet("BooksAll/{id}")]
    public async Task<ActionResult<BookDTO>> GetBooksWithAll( int id)
    {
      var book = await _bookRepository.GetBooksWithAll(id);
      if(book == null)
      return NotFound();
      var bookDtos = _mapper.Map<BookDTO>(book);
      return Ok(bookDtos);

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
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, CreateBookDTO entity)
    {
      var searchBook = await _repository.GetOne(id);
      if (searchBook == null)
      {
        return NotFound();
      }

      _mapper.Map(entity, searchBook);
      var result = await _repository.Update(searchBook);
      if (result)
      {
        return NoContent();
      }
      return BadRequest();
    }
 [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id )
    {
      var searchBook = await _repository.GetOne(id);
      if (searchBook == null)
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
