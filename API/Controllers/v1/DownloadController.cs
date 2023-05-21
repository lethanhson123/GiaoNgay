
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;

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

        [HttpPost]
        [Route("GetYear")]
        public virtual List<DateHelper> GetYear()
        {
            var result = GlobalHelper.Year();
            return result;
        }
        [HttpPost]
        [Route("GetMonth")]
        public virtual List<DateHelper> GetMonth()
        {
            var result = GlobalHelper.Month();
            return result;
        }
        [HttpPost]
        [Route("GetDay")]
        public virtual List<DateHelper> GetDay()
        {
            var result = GlobalHelper.Day();
            return result;
        }
    }
}
