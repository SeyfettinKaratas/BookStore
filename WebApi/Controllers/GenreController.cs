using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.Application.GenreOperations.Queries;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController:ControllerBase
    {
        private readonly BookStoreDBcontext _context;
        private readonly IMapper _mapper;
        public GenreController(BookStoreDBcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult GetGenres()
        {
            GetGenresQuery query=new GetGenresQuery(_context,_mapper);
            var obj=query.Handle();
            return Ok(obj);
        }
         [HttpGet("id")]
        public ActionResult GetGenresDetail(int id)
        {
            GetGenreDetailQuery query=new GetGenreDetailQuery(_context,_mapper);
            query.GenreID=id;
            GetGenreDetailQueryValidator validator=new GetGenreDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var obj=query.Handle();
            return Ok(obj);
        }
        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command=new CreateGenreCommand(_context);
            command.Model=newGenre;
            CreateGenreCommandValidator validator=new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPut("id")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel model)
        {
            UpdateGenreCommand command=new UpdateGenreCommand(_context);
            command.GenreID=id;
            command.Model=model;
            UpdateGenreCommandValidator validator=new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpDelete ("id")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command=new DeleteGenreCommand(_context);
            command.GenreID=id;
            DeleteGenreCommandValidator validator=new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
    
}