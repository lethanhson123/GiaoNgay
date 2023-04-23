namespace Data.Repository.Implement
{
    public class BankRepository : BaseRepository<Bank>, IBankRepository    
    {
        private readonly GiaoNgayContext _context;        
        public BankRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
