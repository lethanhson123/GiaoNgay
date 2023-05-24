namespace Data.Repository.Implement
{
    public class MembershipAuthenticationTokenRepository : BaseRepository<MembershipAuthenticationToken>, IMembershipAuthenticationTokenRepository
    {
        private readonly GiaoNgayContext _context;        
        public MembershipAuthenticationTokenRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
