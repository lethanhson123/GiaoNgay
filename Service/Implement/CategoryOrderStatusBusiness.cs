namespace Service.Implement
{
	public class CategoryOrderStatusBusiness : BaseBusiness<CategoryOrderStatus, ICategoryOrderStatusRepository>, ICategoryOrderStatusBusiness
    {
		private readonly ICategoryOrderStatusRepository _categoryOrderStatusRepository;
		public CategoryOrderStatusBusiness(ICategoryOrderStatusRepository categoryOrderStatusRepository) : base(categoryOrderStatusRepository)
		{
            _categoryOrderStatusRepository = categoryOrderStatusRepository;
		}		
	}
}
