namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class MembershipAuthenticationTokenController : BaseController<MembershipAuthenticationToken, IMembershipAuthenticationTokenBusiness>
    {
        private readonly IMembershipAuthenticationTokenBusiness _membershipAuthenticationTokenBusiness;
        public MembershipAuthenticationTokenController(IMembershipAuthenticationTokenBusiness membershipAuthenticationTokenBusiness) : base(membershipAuthenticationTokenBusiness)
        {
            _membershipAuthenticationTokenBusiness = membershipAuthenticationTokenBusiness;
        }
        [HttpPost]
        [Route("GetByAuthenticationToken")]
        public virtual MembershipAuthenticationToken GetByAuthenticationToken()
        {
            string authenticationToken = JsonConvert.DeserializeObject<string>(Request.Form["data"]);
            var result = _membershipAuthenticationTokenBusiness.GetByAuthenticationToken(authenticationToken);
            return result;
        }
    }
}
