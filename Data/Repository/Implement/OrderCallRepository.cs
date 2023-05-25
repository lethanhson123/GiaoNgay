namespace Data.Repository.Implement
{
    public class OrderCallRepository : BaseRepository<OrderCall>, IOrderCallRepository
    {
        private readonly GiaoNgayContext _context;        
        public OrderCallRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
