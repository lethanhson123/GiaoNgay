using System;

namespace Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }
        public virtual DbSet<T> DbSet()
        {
            return _context.Set<T>();
        }
        public virtual void Initialization(T model)
        {
            model.LastUpdatedDate = DateTime.Now;
            if (model.CreatedDate == null)
            {
                model.CreatedDate = DateTime.Now;
            }
            if (model.Active == null)
            {
                model.Active = true;
            }
        }
        public virtual int Add(T model)
        {
            int result = 0;
            try
            {
                Initialization(model);
                _context.Set<T>().Add(model);
                result = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        public virtual async Task<int> AddAsync(T model)
        {
            int result = 0;
            try
            {
                Initialization(model);
                _context.Set<T>().Add(model);
                result = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        public virtual int Update(T model)
        {
            int result = 0;
            try
            {
                var existModel = GetByID(model.ID);
                if (existModel != null)
                {
                    existModel = model;
                    Initialization(existModel);
                    _context.Set<T>().Update(existModel);
                }
                result = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        public virtual async Task<int> UpdateAsync(T model)
        {
            int result = 0;
            try
            {
                var existModel = await GetByIDAsync(model.ID);
                if (existModel != null)
                {
                    existModel = model;
                    Initialization(existModel);
                    _context.Set<T>().Update(existModel);
                    result = await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        public virtual int Remove(long ID)
        {
            int result = 0;
            try
            {
                var existModel = GetByID(ID);
                if (existModel != null)
                {
                    _context.Set<T>().Remove(existModel);
                    result = _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        public virtual async Task<int> RemoveAsync(long ID)
        {
            int result = 0;
            try
            {
                var existModel = await GetByIDAsync(ID);
                if (existModel != null)
                {
                    _context.Set<T>().Remove(existModel);
                    result = await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        public virtual int AddRange(List<T> list)
        {
            int result = 0;
            if (list.Count > 0)
            {
                _context.Set<T>().AddRange(list);
                result = _context.SaveChanges();
            }
            return result;
        }
        public virtual async Task<int> AddRangeAsync(List<T> list)
        {
            int result = 0;
            if (list.Count > 0)
            {
                _context.Set<T>().AddRange(list);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }
        public virtual int UpdateRange(List<T> list)
        {
            int result = 0;
            if (list.Count > 0)
            {
                _context.Set<T>().UpdateRange(list);
                result = _context.SaveChanges();
            }
            return result;
        }
        public virtual async Task<int> UpdateRangeAsync(List<T> list)
        {
            int result = 0;
            if (list.Count > 0)
            {
                _context.Set<T>().UpdateRange(list);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }
        public virtual int RemoveRange(List<T> list)
        {
            int result = 0;
            if (list.Count > 0)
            {
                _context.Set<T>().RemoveRange(list);
                result = _context.SaveChanges();
            }
            return result;
        }
        public virtual async Task<int> RemoveRangeAsync(List<T> list)
        {
            int result = 0;
            if (list.Count > 0)
            {
                _context.Set<T>().RemoveRange(list);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }
        public virtual IQueryable<T> GetByCondition(Expression<Func<T, bool>> whereCondition)
        {
            var result = _context.Set<T>().AsNoTracking().Where(whereCondition);
            return result;
        }

        public virtual T GetByID(long ID)
        {
            var result = _context.Set<T>().AsNoTracking().FirstOrDefault(model => model.ID == ID);
            if (result == null)
            {
                result = (T)Activator.CreateInstance(typeof(T));
                result.Active = GlobalHelper.InitializationBool;
            }
            return result;
        }
        public virtual async Task<T> GetByIDAsync(long ID)
        {
            var result = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(model => model.ID == ID);
            if (result == null)
            {
                result = (T)Activator.CreateInstance(typeof(T));
                result.Active = GlobalHelper.InitializationBool;
            }
            return result;
        }

        public virtual List<T> GetAllToList()
        {
            var result = _context.Set<T>().AsNoTracking().ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetAllToListAsync()
        {
            var result = await _context.Set<T>().AsNoTracking().ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByActiveToList(bool active)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.Active == active).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByActiveToListAsync(bool active)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.Active == active).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByParentIDToList(long parentID)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.ParentID == parentID).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByParentIDToListAsync(long parentID)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.ParentID == parentID).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByParentIDAndActiveToList(long parentID, bool active)
        {
            var result = _context.Set<T>().AsNoTracking().Where(item => item.ParentID == parentID && item.Active == active).ToList();
            return result ?? new List<T>();
        }
        public virtual async Task<List<T>> GetByParentIDAndActiveToListAsync(long parentID, bool active)
        {
            var result = await _context.Set<T>().AsNoTracking().Where(item => item.ParentID == parentID && item.Active == active).ToListAsync();
            return result ?? new List<T>();
        }
        public virtual List<T> GetByPageAndPageSizeToList(int page, int pageSize)
        {
            var result = _context.Set<T>().AsNoTracking().Skip(page * pageSize).Take(pageSize).ToList();
            return result;
        }
        public virtual async Task<List<T>> GetByPageAndPageSizeToListAsync(int page, int pageSize)
        {
            var result = await _context.Set<T>().AsNoTracking().Skip(page * pageSize).Take(pageSize).ToListAsync();
            return result;
        }
        public virtual string ExecuteNonQueryByStoredProcedure(string storedProcedureName, params SqlParameter[] parameters)
        {
            var result = GlobalHelper.InitializationString;
            try
            {
                result = SQLHelper.ExecuteNonQuery(_context.Database.GetConnectionString(), storedProcedureName, parameters);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return result;
        }
        public virtual async Task<string> ExecuteNonQueryByStoredProcedureAsync(string storedProcedureName, params SqlParameter[] parameters)
        {
            var result = GlobalHelper.InitializationString;
            try
            {
                result = await SQLHelper.ExecuteNonQueryAsync(_context.Database.GetConnectionString(), storedProcedureName, parameters);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return result;
        }
        public virtual List<T> GetByStoredProcedureToList(string storedProcedureName, params SqlParameter[] parameters)
        {
            List<T> result = new List<T>();
            try
            {
                DataTable dt = SQLHelper.FillDataTable(_context.Database.GetConnectionString(), storedProcedureName, parameters);
                result = SQLHelper.ToList<T>(dt);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return result;
        }
        public virtual async Task<List<T>> GetByStoredProcedureToListAsync(string storedProcedureName, params SqlParameter[] parameters)
        {
            List<T> result = new List<T>();
            try
            {
                DataTable dt = await SQLHelper.FillDataTableAsync(_context.Database.GetConnectionString(), storedProcedureName, parameters);
                result = SQLHelper.ToList<T>(dt);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return result;
        }
    }
}
