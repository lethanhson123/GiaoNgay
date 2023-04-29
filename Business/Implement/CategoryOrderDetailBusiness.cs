namespace Business.Implement
{
	public class CategoryOrderDetailBusiness : BaseBusiness<CategoryOrderDetail, ICategoryOrderDetailRepository>, ICategoryOrderDetailBusiness
    {
		private readonly ICategoryOrderDetailRepository _categoryOrderDetailRepository;
		public CategoryOrderDetailBusiness(ICategoryOrderDetailRepository categoryOrderDetailRepository) : base(categoryOrderDetailRepository)
		{
            _categoryOrderDetailRepository = categoryOrderDetailRepository;
		}		
	}
}
