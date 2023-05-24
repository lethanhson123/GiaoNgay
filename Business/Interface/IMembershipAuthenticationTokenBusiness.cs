namespace Business.Interface
{
	public interface IMembershipAuthenticationTokenBusiness : IBaseBusiness<MembershipAuthenticationToken>
	{
        MembershipAuthenticationToken GetByAuthenticationToken(string authenticationToken);
    }
}
