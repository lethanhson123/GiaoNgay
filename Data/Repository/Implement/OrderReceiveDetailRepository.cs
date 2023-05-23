namespace Data.Repository.Implement
{
    public class OrderReceiveDetailRepository : BaseRepository<OrderReceiveDetail>, IOrderReceiveDetailRepository
    {
        private readonly GiaoNgayContext _context;        
        public OrderReceiveDetailRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
