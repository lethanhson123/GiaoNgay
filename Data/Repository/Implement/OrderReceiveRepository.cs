namespace Data.Repository.Implement
{
    public class OrderReceiveRepository : BaseRepository<OrderReceive>, IOrderReceiveRepository
    {
        private readonly GiaoNgayContext _context;        
        public OrderReceiveRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
