namespace Data.Repository.Implement
{
    public class OrderDeliveryDetailRepository : BaseRepository<OrderDeliveryDetail>, IOrderDeliveryDetailRepository
    {
        private readonly GiaoNgayContext _context;        
        public OrderDeliveryDetailRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
