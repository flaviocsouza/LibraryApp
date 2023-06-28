using AutoMapper;
using LibraryApi.DTO;
using LibraryBusiness.Interface.Notificator;
using LibraryBusiness.Interface.Repository;
using LibraryBusiness.Interface.Service;
using LibraryBusiness.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{

    [Route("[controller]")]
    public class AuthorController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        private readonly IAuthorService _authorService;

        public AuthorController(
            INotificator notificator,
            IMapper mapper,
            IAuthorRepository authorRepository,
            IAuthorService authorService
        ) : base(notificator)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IEnumerable<AuthorDTO>> GetAllAuthors()
        {
            return _mapper.Map<IEnumerable<AuthorDTO>>(await _authorRepository.GetAll());
        }

        [HttpGet("{authorId:Guid}")]
        public async Task<ActionResult<AuthorDTO>> GetAuthorByID(Guid authorId)
        {
            var author = await _authorRepository.GetById(authorId);
            if (author is null) return NotFound();
            return CustomResult(_mapper.Map<AuthorDTO>(author));
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDTO>> InsertAuthor(AuthorDTO authorDTO)
        {
            if (!ModelState.IsValid) CustomResult(ModelState);
            await _authorService.Insert(_mapper.Map<Author>(authorDTO));
            return CustomResult(authorDTO);
        }

        [HttpPut("{authorId:Guid}")]
        public async Task<ActionResult<AuthorDTO>> UpdateAuthor(Guid authorId, AuthorDTO authorDTO)
        {
            if (!ModelState.IsValid) CustomResult(ModelState);
            if (authorId != authorDTO.Id) return BadRequest();
            if(_authorRepository.GetById(authorId).Result is null) return NotFound();

            await _authorService.Update(_mapper.Map<Author>(authorDTO));
            return CustomResult(authorDTO);
        }

        [HttpDelete("{authorId:Guid}")]
        public async Task<ActionResult<AuthorDTO>> DeleteAuthor(Guid authorId)
        {
            var author = await _authorRepository.GetById(authorId);
            if (author is null) return NotFound();

            await _authorService.Delete(authorId);
            return CustomResult(_mapper.Map<AuthorDTO>(author));
        }
    }
}
