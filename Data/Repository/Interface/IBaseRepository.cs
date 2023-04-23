namespace Data.Repository
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        public DbSet<T> DbSet();
        public int Add(T model);
        public Task<int> AddAsync(T model);
        public int Update(T model);
        public Task<int> UpdateAsync(T model);
        public int Remove(long ID);
        public Task<int> RemoveAsync(long ID);
        public int AddRange(List<T> list);
        public Task<int> AddRangeAsync(List<T> list);
        public int UpdateRange(List<T> list);
        public Task<int> UpdateRangeAsync(List<T> list);
        public int RemoveRange(List<T> list);
        public Task<int> RemoveRangeAsync(List<T> list);
        public T GetByID(long ID);
        public Task<T> GetByIDAsync(long ID);
        public List<T> GetAllToList();
        public Task<List<T>> GetAllToListAsync();
        public List<T> GetByPageAndPageSizeToList(int page, int pageSize);
        public Task<List<T>> GetByPageAndPageSizeToListAsync(int page, int pageSize);
    }
}
