namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ProvinceController : BaseController<Province, IProvinceBusiness>
    {
        private readonly IProvinceBusiness _provinceBusiness;
        public ProvinceController(IProvinceBusiness provinceBusiness) : base(provinceBusiness)
        {
            _provinceBusiness = provinceBusiness;
        }
    }
}
