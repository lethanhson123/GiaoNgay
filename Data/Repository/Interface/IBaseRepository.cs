

namespace Data.Repository
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        DbSet<T> DbSet();
        int Add(T model);
        Task<int> AddAsync(T model);
        int Update(T model);
        Task<int> UpdateAsync(T model);
        int Remove(long ID);
        Task<int> RemoveAsync(long ID);
        int AddRange(List<T> list);
        Task<int> AddRangeAsync(List<T> list);
        int UpdateRange(List<T> list);
        Task<int> UpdateRangeAsync(List<T> list);
        int RemoveRange(List<T> list);
        Task<int> RemoveRangeAsync(List<T> list);
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> whereCondition);
        T GetByID(long ID);
        Task<T> GetByIDAsync(long ID);
        List<T> GetAllToList();
        Task<List<T>> GetAllToListAsync();
        List<T> GetByPageAndPageSizeToList(int page, int pageSize);
        Task<List<T>> GetByPageAndPageSizeToListAsync(int page, int pageSize);
        string ExecuteNonQueryByStoredProcedure(string storedProcedureName, params SqlParameter[] parameters);
        Task<string> ExecuteNonQueryByStoredProcedureAsync(string storedProcedureName, params SqlParameter[] parameters);
        List<T> GetByStoredProcedureToList(string storedProcedureName, params SqlParameter[] parameters);
        Task<List<T>> GetByStoredProcedureToListAsync(string storedProcedureName, params SqlParameter[] parameters);
    }
}
