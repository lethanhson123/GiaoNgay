namespace Data.Repository.Implement
{
    public class QuickAccessRepository : BaseRepository<QuickAccess>, IQuickAccessRepository
    {
        private readonly GiaoNgayContext _context;        
        public QuickAccessRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
