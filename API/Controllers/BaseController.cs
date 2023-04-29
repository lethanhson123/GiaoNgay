

namespace API.Controllers
{
    public class BaseController<T, TBaseBusiness> : Controller
        where T : BaseModel
        where TBaseBusiness : IBaseBusiness<T>
    {
        private readonly TBaseBusiness _baseBusiness;

        public BaseController(TBaseBusiness baseBusiness)
        {
            _baseBusiness = baseBusiness;
        }

        //[HttpGet]
        //public virtual async Task<ActionResult<List<T>>> GetAsync()
        //{
        //    var result = await _baseBusiness.GetAllToListAsync();
        //    return Ok(result);
        //}
        //[HttpGet]
        //[Route("{id}")]
        //public virtual async Task<ActionResult<T>> GetAsync(int id)
        //{
        //    var result = await _baseBusiness.GetByIDAsync(id);
        //    return Ok(result);
        //}
        //[HttpPost]
        //public virtual async Task<ActionResult<int>> CreateAsync(T t)
        //{
        //    var result = await _baseBusiness.AddAsync(t);
        //    return Ok(result);
        //}
        //[HttpPut]
        //[Route("{id}")]
        //public virtual async Task<ActionResult<int>> UpdateAsync(T t)
        //{
        //    var result = await _baseBusiness.UpdateAsync(t);
        //    return Ok(result);
        //}
        //[HttpDelete]
        //[Route("{id}")]
        //public virtual async Task<ActionResult<int>> DeleteAsync(int id)
        //{
        //    var result = await _baseBusiness.RemoveAsync(id);
        //    return Ok(result);
        //}

        [HttpPost]
        [Route("Save")]
        public virtual T Save()
        {
            T result = JsonConvert.DeserializeObject<T>(Request.Form["data"]);
            if (result.ID > 0)
            {
                _baseBusiness.Update(result);
            }
            else
            {
                _baseBusiness.Add(result);
            }
            return result;
        }
        [HttpPost]
        [Route("SaveAsync")]
        public virtual async Task<T> SaveAsync()
        {
            T result = JsonConvert.DeserializeObject<T>(Request.Form["data"]);
            if (result.ID > 0)
            {
                await _baseBusiness.UpdateAsync(result);
            }
            else
            {
                await _baseBusiness.AddAsync(result);
            }
            return result;
        }
        [HttpPost]
        [Route("Remove")]
        public virtual int Remove()
        {
            long ID = JsonConvert.DeserializeObject<long>(Request.Form["data"]);
            int result = _baseBusiness.Remove(ID);
            return result;
        }
        [HttpPost]
        [Route("RemoveAsync")]
        public virtual async Task<int> RemoveAsync()
        {
            long ID = JsonConvert.DeserializeObject<long>(Request.Form["data"]);
            int result = await _baseBusiness.RemoveAsync(ID);
            return result;
        }

        [HttpPost]
        [Route("GetByID")]
        public virtual T GetByID()
        {
            long ID = JsonConvert.DeserializeObject<long>(Request.Form["data"]);
            T result = _baseBusiness.GetByID(ID);
            return result;
        }
        [HttpPost]
        [Route("GetByIDAsync")]
        public virtual async Task<T> GetByIDAsync()
        {
            long ID = JsonConvert.DeserializeObject<long>(Request.Form["data"]);
            T result = await _baseBusiness.GetByIDAsync(ID);
            return result;
        }
        [HttpGet]
        [Route("GetByIDAsync2023")]
        public virtual async Task<T> GetByIDAsync2023(long ID)
        {            
            T result = await _baseBusiness.GetByIDAsync(ID);
            return result;
        }
        [HttpPost]
        [Route("GetAllToList")]
        public virtual List<T> GetAllToList()
        {
            var result = _baseBusiness.GetAllToList();
            return result;
        }
        [HttpPost]
        [Route("GetAllToListAsync")]
        public virtual async Task<List<T>> GetAllToListAsync()
        {
            var result = await _baseBusiness.GetAllToListAsync();
            return result;
        }        
    }
}
