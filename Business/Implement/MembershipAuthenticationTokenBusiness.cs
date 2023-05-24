namespace Business.Implement
{
    public class MembershipAuthenticationTokenBusiness : BaseBusiness<MembershipAuthenticationToken, IMembershipAuthenticationTokenRepository>, IMembershipAuthenticationTokenBusiness
    {
        private readonly IMembershipAuthenticationTokenRepository _membershipAuthenticationTokenRepository;
        public MembershipAuthenticationTokenBusiness(IMembershipAuthenticationTokenRepository membershipAuthenticationTokenRepository) : base(membershipAuthenticationTokenRepository)
        {
            _membershipAuthenticationTokenRepository = membershipAuthenticationTokenRepository;
        }
        public MembershipAuthenticationToken GetByAuthenticationToken(string authenticationToken)
        {
            MembershipAuthenticationToken result = new MembershipAuthenticationToken();
            result = _membershipAuthenticationTokenRepository.GetByCondition(model => model.AuthenticationToken == authenticationToken).FirstOrDefault();
            return result;
        }
    }
}
