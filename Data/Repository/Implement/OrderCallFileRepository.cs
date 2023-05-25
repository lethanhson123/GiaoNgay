namespace Data.Repository.Implement
{
    public class OrderCallFileRepository : BaseRepository<OrderCallFile>, IOrderCallFileRepository
    {
        private readonly GiaoNgayContext _context;        
        public OrderCallFileRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
