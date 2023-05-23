namespace Data.Repository.Implement
{
    public class OrderShipperRepository : BaseRepository<OrderShipper>, IOrderShipperRepository
    {
        private readonly GiaoNgayContext _context;        
        public OrderShipperRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
