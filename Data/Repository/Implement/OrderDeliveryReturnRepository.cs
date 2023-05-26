namespace Data.Repository.Implement
{
    public class OrderDeliveryReturnRepository : BaseRepository<OrderDeliveryReturn>, IOrderDeliveryReturnRepository
    {
        private readonly GiaoNgayContext _context;        
        public OrderDeliveryReturnRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
