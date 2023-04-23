namespace Data.Repository.Implement
{
    public class CategoryOrderPaymentRepository : BaseRepository<CategoryOrderPayment>, ICategoryOrderPaymentRepository
    {
        private readonly GiaoNgayContext _context;        
        public CategoryOrderPaymentRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
