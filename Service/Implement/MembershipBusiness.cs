namespace Business.Implement
{
	public class MembershipBusiness : BaseBusiness<Membership, IMembershipRepository>, IMembershipBusiness
    {
		private readonly IMembershipRepository _membershipRepository;
		public MembershipBusiness(IMembershipRepository membershipRepository) : base(membershipRepository)
		{
            _membershipRepository = membershipRepository;
		}		
	}
}
