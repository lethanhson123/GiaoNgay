namespace Service.Interface
{
	public interface IBaseBusiness<T>
		where T : class		
	{		
		int Add(T model);
		Task<int> AddAsync(T model);
		Task<int> AddRangeAsync(List<T> list);
		int AddRange(List<T> list);			
		int Update(T model);
		Task<int> UpdateAsync(T model);		
		int Remove(long ID);
		Task<int> RemoveAsync(long ID);
		int RemoveRange(List<T> list);
		Task<int> RemoveRangeAsync(List<T> list);		
		List<T> GetAllToList();
		Task<List<T>> GetAllToListAsync();
		IQueryable<T> GetByCondition(Expression<Func<T, bool>> whereCondition);
        T GetByID(long ID);
        Task<T> GetByIDAsync(long ID);
        string ExecuteNonQueryByStoredProcedure(string storedProcedureName, params SqlParameter[] parameters);
		Task<string> ExecuteNonQueryByStoredProcedureAsync(string storedProcedureName, params SqlParameter[] parameters);
		List<T> GetByStoredProcedureToList(string storedProcedureName, params SqlParameter[] parameters);
		Task<List<T>> GetByStoredProcedureToListAsync(string storedProcedureName, params SqlParameter[] parameters);	
	}
}
