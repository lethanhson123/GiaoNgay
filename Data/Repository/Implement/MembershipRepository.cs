namespace Data.Repository.Implement
{
    public class MembershipRepository : BaseRepository<Membership>, IMembershipRepository
    {
        private readonly GiaoNgayContext _context;        
        public MembershipRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }        
    }
}
