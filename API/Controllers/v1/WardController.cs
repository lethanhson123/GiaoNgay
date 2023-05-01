namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class WardController : BaseController<Ward, IWardBusiness>
    {
        private readonly IWardBusiness _wardBusiness;
        public WardController(IWardBusiness wardBusiness) : base(wardBusiness)
        {
            _wardBusiness = wardBusiness;
        }      
    }
}
