namespace Data.Repository.Implement
{
    public class OrderDeliveryStatusRepository : BaseRepository<OrderDeliveryStatus>, IOrderDeliveryStatusRepository
    {
        private readonly GiaoNgayContext _context;        
        public OrderDeliveryStatusRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
