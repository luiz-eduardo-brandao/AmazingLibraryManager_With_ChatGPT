using AmazingLibraryManager.LoanService.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AmazingLibraryManager.LoanService.API.Controllers
{
    [ApiController]
    [Route("loan")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }
    }
}