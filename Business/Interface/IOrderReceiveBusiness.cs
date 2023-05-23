namespace Business.Interface
{
	public interface IOrderReceiveBusiness : IBaseBusiness<OrderReceive>
	{
        Task<List<OrderReceive>> GetByYearAndMonthAndDayAndSearchStringToLisAsync(int year, int month, int day, string searchString);
    }
}
