namespace Data.Repository.Implement
{
    public class OrderDeliveryPaymentHistoryRepository : BaseRepository<OrderDeliveryPaymentHistory>, IOrderDeliveryPaymentHistoryRepository
    {
        private readonly GiaoNgayContext _context;        
        public OrderDeliveryPaymentHistoryRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
