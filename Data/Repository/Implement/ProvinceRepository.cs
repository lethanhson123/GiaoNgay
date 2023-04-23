namespace Data.Repository.Implement
{
    public class ProvinceRepository : BaseRepository<Province>, IProvinceRepository
    {
        private readonly GiaoNgayContext _context;        
        public ProvinceRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
