namespace Data.Repository.Implement
{
    public class OrderDeliveryRepository : BaseRepository<OrderDelivery>, IOrderDeliveryRepository
    {
        private readonly GiaoNgayContext _context;        
        public OrderDeliveryRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
