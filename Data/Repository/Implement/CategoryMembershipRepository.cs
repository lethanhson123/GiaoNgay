namespace Data.Repository.Implement
{
    public class CategoryMembershipRepository : BaseRepository<CategoryMembership>, ICategoryMembershipRepository
    {
        private readonly GiaoNgayContext _context;        
        public CategoryMembershipRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
