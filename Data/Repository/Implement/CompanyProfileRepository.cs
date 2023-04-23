namespace Data.Repository.Implement
{
    public class CompanyProfileRepository : BaseRepository<CompanyProfile>, ICompanyProfileRepository
    {
        private readonly GiaoNgayContext _context;        
        public CompanyProfileRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
