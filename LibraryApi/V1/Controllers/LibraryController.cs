using AutoMapper;
using LibraryApi.Controllers;
using LibraryApi.DTO;
using LibraryBusiness.Interface.Notificator;
using LibraryBusiness.Interface.Repository;
using LibraryBusiness.Interface.Service;
using LibraryBusiness.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/{Version:apiVersion}/[controller]")]
    public class LibraryController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ILibraryRepository _libraryRepository;
        private readonly ILibraryService _libraryService;

        public LibraryController(INotificator notificator,
            IMapper mapper,
            ILibraryRepository libraryRepository,
            ILibraryService libraryService
        ) : base(notificator)
        {
            _mapper = mapper;
            _libraryRepository = libraryRepository;
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<IEnumerable<LibraryDTO>> GetAllLibraries()
        {
            return _mapper.Map<IEnumerable<LibraryDTO>>(await _libraryRepository.GetAll());
        }

        [HttpGet("{libraryId:Guid}")]
        public async Task<ActionResult<LibraryDTO>> GetLibraryByID(Guid libraryId)
        {
            var library = await _libraryRepository.GetById(libraryId);
            if (library is null) return NotFound();
            return CustomResult(_mapper.Map<LibraryDTO>(library));
        }

        [HttpPost]
        public async Task<ActionResult<LibraryDTO>> InsertLibrary(LibraryDTO libraryDTO)
        {
            if (!ModelState.IsValid) CustomResult(ModelState);
            await _libraryService.Insert(_mapper.Map<Library>(libraryDTO));
            return CustomResult(libraryDTO);
        }

        [HttpPut("{libraryId:Guid}")]
        public async Task<ActionResult<LibraryDTO>> UpdateLibrary(Guid libraryId, LibraryDTO libraryDTO)
        {
            if (!ModelState.IsValid) CustomResult(ModelState);
            if (libraryId != libraryDTO.Id) return BadRequest();
            if (_libraryRepository.GetById(libraryId).Result is null) return NotFound();

            await _libraryService.Update(_mapper.Map<Library>(libraryDTO));
            return CustomResult(libraryDTO);
        }

        [HttpDelete("{libraryId:Guid}")]
        public async Task<ActionResult<LibraryDTO>> DeleteLibrary(Guid libraryId)
        {
            var library = await _libraryRepository.GetById(libraryId);
            if (library is null) return NotFound();

            await _libraryService.Delete(libraryId);
            return CustomResult(_mapper.Map<LibraryDTO>(library));
        }

    }
}
