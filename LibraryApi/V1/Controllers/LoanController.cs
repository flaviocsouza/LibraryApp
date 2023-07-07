using AutoMapper;
using LibraryApi.Controllers;
using LibraryApi.DTO;
using LibraryBusiness.Interface.Notificator;
using LibraryBusiness.Interface.Repository;
using LibraryBusiness.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/{Version:apiVersion}/[controller]")]
    public class LoanController : MainController
    {
        public readonly IMapper _mapper;
        public readonly ILoanRepository _loanRepository;
        public readonly ILoanService _loanService;

        public LoanController(INotificator notificator,
            IMapper mapper,
            ILoanRepository loanRepository,
            ILoanService loanService
        ) : base(notificator)
        {
            _mapper = mapper;
            _loanRepository = loanRepository;
            _loanService = loanService;
        }

        [HttpGet]
        public async Task<IEnumerable<LoanDTO>> GetAllLoans()
        {
            return _mapper.Map<IEnumerable<LoanDTO>>(await _loanRepository.GetAll());
        }

        [HttpGet("{loanId:Guid}")]
        public async Task<ActionResult<LoanDTO>> GetLoanByID(Guid loanId)
        {
            var loan = await _loanRepository.GetById(loanId);
            if (loan is null) return NotFound();
            return _mapper.Map<LoanDTO>(loan);
        }

        [HttpPost("Lend-Book")]
        public async Task<ActionResult> LendBook(LoanDTO loanDTO)
        {
            if (!ModelState.IsValid) CustomResult(ModelState);
            await _loanService.LendBook(loanDTO.MemberId, loanDTO.BookId);
            return CustomResult();
        }

        [HttpPost("Renew-Loan")]
        public async Task<ActionResult> RenewLoan([FromBody] Guid loanId)
        {
            if (_loanRepository.GetById(loanId).Result is null) return NotFound();
            await _loanService.RenewLoan(loanId);
            return CustomResult();
        }


        [HttpPost("Return-Book")]
        public async Task<ActionResult> ReturnBook([FromBody] Guid loanId)
        {
            if (_loanRepository.GetById(loanId).Result is null) return NotFound();
            await _loanService.ReturnBook(loanId);
            return CustomResult();
        }

        [HttpGet("Compute-Late-Fee/{loanId:Guid}")]
        public async Task<ActionResult<decimal>> ComputeLateFee(Guid loanId)
        {
            if (_loanRepository.GetById(loanId).Result is null) return NotFound();
            return CustomResult(await _loanService.ComputeLateFee(loanId));
        }
    }
}
