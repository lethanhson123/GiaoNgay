namespace Data.Repository.Implement
{
    public class WardRepository : BaseRepository<Ward>, IWardRepository
    {
        private readonly GiaoNgayContext _context;        
        public WardRepository(GiaoNgayContext context) : base(context)
        {
            _context = context;            
        }
    }
}
