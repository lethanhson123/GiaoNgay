namespace API.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class BankController : BaseController<Bank, IBankRepository>
    {
        private readonly IBankRepository _bankRepository;
        public BankController(IBankRepository bankRepository) : base(bankRepository)
        {
            _bankRepository = bankRepository;
        }
    }
}
