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
    }
}
