namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class MembershipProfileController : BaseController<MembershipProfile, IMembershipProfileBusiness>
    {
        private readonly IMembershipProfileBusiness _membershipProfileBusiness;
        public MembershipProfileController(IMembershipProfileBusiness membershipProfileBusiness) : base(membershipProfileBusiness)
        {
            _membershipProfileBusiness = membershipProfileBusiness;
        }
    }
}
