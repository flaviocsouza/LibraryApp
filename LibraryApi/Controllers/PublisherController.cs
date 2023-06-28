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
    public class PublisherController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IPublisherRepository _publsiherRepository;
        private readonly IPublisherService _publisherService;

        public PublisherController(INotificator notificator,
            IMapper mapper, 
            IPublisherRepository publisherRepository,
            IPublisherService publisherService
        ) : base(notificator)
        {
            _mapper = mapper;
            _publsiherRepository = publisherRepository;
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<IEnumerable<PublisherDTO>> GetAllPublishers()
        {
            return _mapper.Map<IEnumerable<PublisherDTO>>(await _publsiherRepository.GetAll());
        }

        [HttpGet("{publisherId:Guid}")]
        public async  Task<ActionResult<PublisherDTO>> GetPublisherByID(Guid publisherId)
        {
            var publisher = await _publsiherRepository.GetById(publisherId);
            if (publisher is null) return NotFound();
            return CustomResult(_mapper.Map<PublisherDTO>(publisher));
        }

        [HttpPost]
        public async Task<ActionResult<PublisherDTO>> InsertPublisher(PublisherDTO publisherDTO)
        {
            if (!ModelState.IsValid) CustomResult(ModelState);
            await _publisherService.Insert(_mapper.Map<Publisher>(publisherDTO));
            return CustomResult(publisherDTO);
        }

        [HttpPut("{publisherId:Guid}")]
        public async Task<ActionResult<PublisherDTO>> UpdatePublisher(Guid publisherId, PublisherDTO publisherDTO)
        {
            if (!ModelState.IsValid) CustomResult(ModelState);
            if (publisherId != publisherDTO.Id) return BadRequest();
            if (_publsiherRepository.GetById(publisherId).Result is null) return NotFound();

            await _publisherService.Update(_mapper.Map<Publisher>(publisherDTO));
            return CustomResult(publisherDTO);
        }

        [HttpDelete("{publisherId:Guid}")]
        public async Task<ActionResult<PublisherDTO>> DeletePublisher(Guid publisherId)
        {
            var publisher = await _publsiherRepository.GetById(publisherId);
            if (publisher is null) return NotFound();
            
            await _publisherService.Delete(publisherId);
            return CustomResult(_mapper.Map<PublisherDTO>(publisher));
        }
    }
}
