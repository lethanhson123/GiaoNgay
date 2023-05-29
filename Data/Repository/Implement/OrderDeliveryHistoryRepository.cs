namespace Data.Repository.Implement
{
    public class OrderDeliveryHistoryRepository : BaseRepository<OrderDeliveryHistory>, IOrderDeliveryHistoryRepository
    {
        private readonly GiaoNgayContext _context;        
        public OrderDeliveryHistoryRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
