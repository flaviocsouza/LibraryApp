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
    public class BookController : MainController
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(
            INotificator notificator,
            IMapper mapper,
            IBookRepository bookRepository,
            IBookService bookService
        ) : base(notificator)
        {
            _bookRepository = bookRepository;
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BookDTO>> GetAllBooks()
        {
            return _mapper.Map<IEnumerable<BookDTO>>( await _bookRepository.GetAll());
        }

        [HttpGet("{bookId:Guid}")]
        public async Task<ActionResult<BookDTO>> GetBookById(Guid bookId)
        {
            var book = await _bookRepository.GetById(bookId);
            if (book == null) return NotFound();
            return Ok(_mapper.Map<BookDTO>(book));
        }

        [HttpPost]
        public async Task<ActionResult<BookDTO>> RegisterBook(BookDTO bookDTO)
        {
            if (!ModelState.IsValid) CustomResult(ModelState);
            await _bookService.RegisterBook(_mapper.Map<Book>(bookDTO));
            return CustomResult(bookDTO);
        }

        [HttpPut("{bookId:Guid}")]
        public async Task<ActionResult<BookDTO>> UpdateBook(Guid bookId, BookDTO bookDTO)
        {
            if (!ModelState.IsValid) CustomResult(ModelState);
            if (bookId != bookDTO.Id) return BadRequest();
            if (_bookRepository.GetById(bookId).Result is null) return NotFound();

            await _bookService.UpdateBook(_mapper.Map<Book>(bookDTO));

            return CustomResult(bookDTO);
        }

        [HttpDelete("{bookId:Guid}")]
        public async Task<ActionResult<BookDTO>> DeleteBook(Guid bookId)
        {
            var book = _bookRepository.GetById(bookId);
            if(book is null) return NotFound();

            await _bookService.Delete(bookId);
            return CustomResult(_mapper.Map<BookDTO>(book));
        }
    }
}
