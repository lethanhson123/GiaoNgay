namespace Service.Implement
{
	public class CategoryMembershipBusiness : BaseBusiness<CategoryMembership, ICategoryMembershipRepository>, ICategoryMembershipBusiness
    {
		private readonly ICategoryMembershipRepository _categoryMembershipRepository;
		public CategoryMembershipBusiness(ICategoryMembershipRepository categoryMembershipRepository) : base(categoryMembershipRepository)
		{
            _categoryMembershipRepository = categoryMembershipRepository;
		}		
	}
}
