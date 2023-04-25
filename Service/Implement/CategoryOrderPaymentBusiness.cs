namespace Service.Implement
{
	public class CategoryOrderPaymentBusiness : BaseBusiness<CategoryOrderPayment, ICategoryOrderPaymentRepository>, ICategoryOrderPaymentBusiness
    {
		private readonly ICategoryOrderPaymentRepository _categoryOrderPaymentRepository;
		public CategoryOrderPaymentBusiness(ICategoryOrderPaymentRepository categoryOrderPaymentRepository) : base(categoryOrderPaymentRepository)
		{
            _categoryOrderPaymentRepository = categoryOrderPaymentRepository;
		}		
	}
}
