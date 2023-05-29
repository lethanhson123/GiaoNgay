namespace Business.Interface
{
	public interface IMembershipBusiness : IBaseBusiness<Membership>
	{
        Task<List<Membership>> GetByParentIDToListAsync(long parentID);
        Membership Authentication(Membership membership);
        Task<List<Membership>> GetByTotalDebtGreaterThanZeroToListAsync();
    }
}
