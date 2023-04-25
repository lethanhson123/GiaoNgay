namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class StreetWardController : BaseController<StreetWard, IStreetWardBusiness>
    {
        private readonly IStreetWardBusiness _streetWardBusiness;
        public StreetWardController(IStreetWardBusiness streetWardBusiness) : base(streetWardBusiness)
        {
            _streetWardBusiness = streetWardBusiness;
        }
    }
}
