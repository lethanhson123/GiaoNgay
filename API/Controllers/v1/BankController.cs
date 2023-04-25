namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BankController : BaseController<Bank, IBankBusiness>
    {
        private readonly IBankBusiness _bankBusiness;
        public BankController(IBankBusiness bankBusiness) : base(bankBusiness)
        {
            _bankBusiness = bankBusiness;
        }
    }
}
