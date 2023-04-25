namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CategoryOrderPaymentController : BaseController<CategoryOrderPayment, ICategoryOrderPaymentBusiness>
    {
        private readonly ICategoryOrderPaymentBusiness _categoryOrderPaymentBusiness;
        public CategoryOrderPaymentController(ICategoryOrderPaymentBusiness categoryOrderPaymentBusiness) : base(categoryOrderPaymentBusiness)
        {
            _categoryOrderPaymentBusiness = categoryOrderPaymentBusiness;
        }
    }
}
