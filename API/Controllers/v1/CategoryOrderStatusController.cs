namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CategoryOrderStatusController : BaseController<CategoryOrderStatus, ICategoryOrderStatusBusiness>
    {
        private readonly ICategoryOrderStatusBusiness _categoryOrderStatusBusiness;
        public CategoryOrderStatusController(ICategoryOrderStatusBusiness categoryOrderStatusBusiness) : base(categoryOrderStatusBusiness)
        {
            _categoryOrderStatusBusiness = categoryOrderStatusBusiness;
        }
    }
}
