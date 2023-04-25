namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CategoryOrderDetailController : BaseController<CategoryOrderDetail, ICategoryOrderDetailBusiness>
    {
        private readonly ICategoryOrderDetailBusiness _categoryOrderDetailBusiness;
        public CategoryOrderDetailController(ICategoryOrderDetailBusiness categoryOrderDetailBusiness) : base(categoryOrderDetailBusiness)
        {
            _categoryOrderDetailBusiness = categoryOrderDetailBusiness;
        }
    }
}
