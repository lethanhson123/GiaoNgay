namespace Data.Repository.Implement
{
    public class StreetRepository : BaseRepository<Street>, IStreetRepository
    {
        private readonly GiaoNgayContext _context;        
        public StreetRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
