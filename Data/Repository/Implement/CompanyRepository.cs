namespace Data.Repository.Implement
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        private readonly GiaoNgayContext _context;        
        public CompanyRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
