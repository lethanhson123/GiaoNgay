namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class StreetController : BaseController<Street, IStreetBusiness>
    {
        private readonly IStreetBusiness _streetBusiness;
        public StreetController(IStreetBusiness streetBusiness) : base(streetBusiness)
        {
            _streetBusiness = streetBusiness;
        }
    }
}
