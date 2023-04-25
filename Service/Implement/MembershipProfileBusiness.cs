namespace Service.Implement
{
	public class MembershipProfileBusiness : BaseBusiness<MembershipProfile, IMembershipProfileRepository>, IMembershipProfileBusiness
    {
		private readonly IMembershipProfileRepository _membershipProfileRepository;
		public MembershipProfileBusiness(IMembershipProfileRepository membershipProfileRepository) : base(membershipProfileRepository)
		{
            _membershipProfileRepository = membershipProfileRepository;
		}		
	}
}
