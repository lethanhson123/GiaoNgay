namespace Data.Repository.Implement
{
    public class OrderDeliveryFileRepository : BaseRepository<OrderDeliveryFile>, IOrderDeliveryFileRepository
    {
        private readonly GiaoNgayContext _context;        
        public OrderDeliveryFileRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
