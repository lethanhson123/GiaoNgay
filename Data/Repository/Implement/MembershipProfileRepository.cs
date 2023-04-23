namespace Data.Repository.Implement
{
    public class MembershipProfileRepository : BaseRepository<MembershipProfile>, IMembershipProfileRepository
    {
        private readonly GiaoNgayContext _context;        
        public MembershipProfileRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
