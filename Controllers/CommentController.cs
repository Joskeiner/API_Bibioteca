using APIBiblioteca.DAL.Interface;
using APIBiblioteca.DTO;
using APIBiblioteca.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIBiblioteca.Controllers{
    [Route("api/comment")]
    [ApiController]

    public class CommentController :ControllerBase
    {
            private readonly IGenericRepository<Comment> _repository;
            private readonly IMapper _mapper;
        
        public CommentController(IGenericRepository<Comment> repository,IMapper mapper )
        {
            _mapper = mapper;
            _repository = repository;

        }
[HttpPost]
    public async Task<ActionResult> Create(CommentDTO entity)
    {
      var comment = _mapper.Map<Comment>(entity);

      var result = await _repository.Insert(comment);
      if (!result)
      {
        return NotFound();
      }
      var dto = _mapper.Map<CommentDTO>(entity);
    
      return  Ok(dto);
    }


    }
}