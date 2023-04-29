
namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DownloadController : BaseController<Bank, IBankBusiness>
    {
        private readonly IBankBusiness _bankBusiness;
        public DownloadController(IBankBusiness bankBusiness
            ) : base(bankBusiness)
        {
            _bankBusiness = bankBusiness;
        }
    }
}
