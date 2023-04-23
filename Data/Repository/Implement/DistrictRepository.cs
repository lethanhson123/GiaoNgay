namespace Data.Repository.Implement
{
    public class DistrictRepository : BaseRepository<District>, IDistrictRepository
    {
        private readonly GiaoNgayContext _context;        
        public DistrictRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
