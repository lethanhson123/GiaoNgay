namespace Business.Interface
{
	public interface IOrderCallBusiness : IBaseBusiness<OrderCall>
	{
        Task<List<OrderCall>> GetByYearAndMonthAndDayAndSearchStringToLisAsync(int year, int month, int day, string searchString);
        Task<List<OrderCall>> GetByMembershipIDYearAndMonthAndDayAndSearchStringToLisAsync(long membershipID, int year, int month, int day, string searchString);
    }
}
