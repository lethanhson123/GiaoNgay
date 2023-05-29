namespace Data.Repository.Interface
{
    public interface IMembershipRepository : IBaseRepository<Membership>
    {
        Task<List<Membership>> GetByTotalDebtGreaterThanZeroToListAsync();
    }
}
