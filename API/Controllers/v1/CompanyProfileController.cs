namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CompanyProfileController : BaseController<CompanyProfile, ICompanyProfileBusiness>
    {
        private readonly ICompanyProfileBusiness _companyProfileBusiness;
        public CompanyProfileController(ICompanyProfileBusiness companyProfileBusiness) : base(companyProfileBusiness)
        {
            _companyProfileBusiness = companyProfileBusiness;
        }
    }
}
