namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CompanyController : BaseController<Company, ICompanyBusiness>
    {
        private readonly ICompanyBusiness _companyBusiness;
        public CompanyController(ICompanyBusiness companyBusiness) : base(companyBusiness)
        {
            _companyBusiness = companyBusiness;
        }
    }
}
