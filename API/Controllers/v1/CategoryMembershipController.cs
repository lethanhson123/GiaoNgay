namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CategoryMembershipController : BaseController<CategoryMembership, ICategoryMembershipBusiness>
    {
        private readonly ICategoryMembershipBusiness _categoryMembershipBusiness;
        public CategoryMembershipController(ICategoryMembershipBusiness categoryMembershipBusiness) : base(categoryMembershipBusiness)
        {
            _categoryMembershipBusiness = categoryMembershipBusiness;
        }
    }
}
