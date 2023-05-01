namespace Business.Interface
{
	public interface IMembershipBusiness : IBaseBusiness<Membership>
	{
        Task<List<Membership>> GetByParentIDToListAsync(long parentID);
    }
}
