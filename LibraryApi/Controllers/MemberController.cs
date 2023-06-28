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
    public class MemberController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IMemberRepository _memberRepository;
        private readonly IMemberService _memberService;

        public MemberController(INotificator notificator,
            IMapper mapper,
            IMemberService memberService, 
            IMemberRepository memberRepository
        ) : base(notificator)
        {
            _memberService = memberService;
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MemberDTO>> GetAllMembers()
        {
            return  _mapper.Map<IEnumerable<MemberDTO>>(await _memberRepository.GetAll());
        }

        [HttpGet("{memberId:Guid}")]
        public async Task<ActionResult<MemberDTO>> GetMemberById(Guid memberId)
        {
            var member = await _memberRepository.GetById(memberId);
            if (member is null) return NotFound();
            return CustomResult(_mapper.Map<MemberDTO>(member));
        }

        [HttpPost]
        public async Task<ActionResult<MemberDTO>> RegisterMember(MemberDTO memberDTO)
        {
            await _memberService.Insert(_mapper.Map<Member>(memberDTO));
            return CustomResult(memberDTO);
        }

        [HttpPut("{memberId:Guid}")]
        public async Task<ActionResult<MemberDTO>> UpdateMember(Guid memberId, MemberDTO memberDTO)
        {
            if(memberId != memberDTO.Id) return BadRequest();
            if (_memberRepository.GetById(memberId).Result is null) return NotFound();

            await _memberService.Update(_mapper.Map<Member>(memberDTO));
            return CustomResult(memberDTO);
        }

        [HttpDelete("{memberId:Guid}")]
        public async Task<ActionResult<MemberDTO>> DeleteMember(Guid memberId)
        {
            var member = await _memberRepository.GetById(memberId);
            if(member is null) return NotFound();
            await _memberService.Delete(memberId);
            return CustomResult(member);
        }
    }
}
