namespace Data.Repository.Implement
{
    public class CategoryOrderStatusRepository : BaseRepository<CategoryOrderStatus>, ICategoryOrderStatusRepository
    {
        private readonly GiaoNgayContext _context;        
        public CategoryOrderStatusRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
