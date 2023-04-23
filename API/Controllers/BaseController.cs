


namespace API.Controllers
{
    public class BaseController<T, TRepository> : Controller
        where T : BaseModel
        where TRepository : IBaseRepository<T>
    {
        private readonly TRepository _repository;

        public BaseController(TRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public virtual async Task<ActionResult<List<T>>> GetAsync()
        {
            var result = await _repository.GetAllToListAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("{id}")]
        public virtual async Task<ActionResult<T>> GetAsync(int id)
        {
            var result = await _repository.GetByIDAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public virtual async Task<ActionResult<int>> CreateAsync(T t)
        {
            var result = await _repository.AddAsync(t);
            return Ok(result);
        }
        [HttpPut]
        [Route("{id}")]
        public virtual async Task<ActionResult<int>> UpdateAsync(T t)
        {
            var result = await _repository.UpdateAsync(t);
            return Ok(result);
        }
        [HttpDelete]
        [Route("{id}")]
        public virtual async Task<ActionResult<int>> DeleteAsync(int id)
        {
            var result = await _repository.RemoveAsync(id);
            return Ok(result);
        }
    }
}
