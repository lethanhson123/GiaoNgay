namespace Data.Repository.Implement
{
    public class OrderShipperDetailRepository : BaseRepository<OrderShipperDetail>, IOrderShipperDetailRepository
    {
        private readonly GiaoNgayContext _context;        
        public OrderShipperDetailRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
