namespace Data.Repository.Implement
{
    public class MembershipFileRepository : BaseRepository<MembershipFile>, IMembershipFileRepository    
    {
        private readonly GiaoNgayContext _context;        
        public MembershipFileRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
