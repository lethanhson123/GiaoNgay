namespace Data.Repository.Implement
{
    public class CategoryOrderDetailRepository : BaseRepository<CategoryOrderDetail>, ICategoryOrderDetailRepository
    {
        private readonly GiaoNgayContext _context;        
        public CategoryOrderDetailRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
