using Microsoft.AspNetCore.Hosting;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DistrictController : BaseController<District, IDistrictBusiness>
    {
        private readonly IDistrictBusiness _districtBusiness;
        public DistrictController(IDistrictBusiness districtBusiness) : base(districtBusiness)
        {
            _districtBusiness = districtBusiness;
        }       
    }
}
