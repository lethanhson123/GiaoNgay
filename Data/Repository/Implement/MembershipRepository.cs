namespace Data.Repository.Implement
{
    public class MembershipRepository : BaseRepository<Membership>, IMembershipRepository
    {
        private readonly GiaoNgayContext _context;        
        public MembershipRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
        public async Task<List<Membership>> GetByTotalDebtGreaterThanZeroToListAsync()
        {
            List<Membership> list = new List<Membership>();
           
            DataTable dt = await SQLHelper.FillDataTableAsync(GlobalHelper.SQLServerConectionString, "sp_MembershipGetByTotalDebtGreaterThanZero");
            list = SQLHelper.ToList<Membership>(dt);
            return list;
        }       
    }
}
