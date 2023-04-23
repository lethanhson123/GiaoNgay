namespace Data.Repository.Implement
{
    public class StreetWardRepository : BaseRepository<StreetWard>, IStreetWardRepository
    {
        private readonly GiaoNgayContext _context;        
        public StreetWardRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
