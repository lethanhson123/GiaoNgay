namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BankController : BaseController<Bank, IBankRepository>
    {
        private readonly IBankRepository _bankRepository;
        public BankController(IBankRepository bankRepository) : base(bankRepository)
        {
            _bankRepository = bankRepository;
        }
    }
}
