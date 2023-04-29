namespace API.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class BankController : BaseController<Bank, IBankBusiness>
    {
        private readonly IBankBusiness _bankBusiness;
        public BankController(IBankBusiness bankBusiness) : base(bankBusiness)
        {
            _bankBusiness = bankBusiness;
        }
    }
}
