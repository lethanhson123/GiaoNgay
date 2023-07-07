using Microsoft.AspNetCore.Hosting;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class MembershipController : BaseController<Membership, IMembershipBusiness>
    {
        private readonly IMembershipBusiness _membershipBusiness;
        public MembershipController(IMembershipBusiness membershipBusiness) : base(membershipBusiness)
        {
            _membershipBusiness = membershipBusiness;
        }
        [HttpPost]
        [Route("Authentication")]
        public virtual Membership Authentication()
        {
            Membership result = JsonConvert.DeserializeObject<Membership>(Request.Form["data"]);
            result = _membershipBusiness.Authentication(result);
            return result;
        }
        [HttpPost]
        [Route("GetByTotalDebtGreaterThanZeroToListAsync")]
        public virtual async Task<List<Membership>> GetByTotalDebtGreaterThanZeroToListAsync()
        {
            return await _membershipBusiness.GetByTotalDebtGreaterThanZeroToListAsync();
        }
        [HttpPost]
        [Route("GetByPhone")]
        public virtual Membership GetByPhone()
        {
            string phone = JsonConvert.DeserializeObject<string>(Request.Form["data"]);
            Membership result = _membershipBusiness.GetByPhone(phone);
            return result;
        }
        [HttpPost]
        [Route("GetByPhoneAsync")]
        public virtual async Task<Membership> GetByPhoneAsync()
        {
            Membership result = new Membership();
            try
            {
                //string phone = JsonConvert.DeserializeObject<string>(Request.Form["data"]);
                string phone = Request.Form["data"].ToString();
                result = await _membershipBusiness.GetByPhoneAsync(phone);
            }
            catch (Exception e)
            {
                string message = e.Message;
            }
            return result;
        }
        [HttpGet]
        [Route("XoayTrai")]
        public async Task<List<Membership>> XoayTrai(long parentID)
        {          
            return await _membershipBusiness.GetByParentIDToListAsync(parentID);
        }
    }
}
