namespace Business.Interface
{
	public interface IOrderReceiveBusiness : IBaseBusiness<OrderReceive>
	{
        Task<List<OrderReceive>> GetByYearAndMonthAndDayAndSearchStringToLisAsync(int year, int month, int day, string searchString);
        Task<List<OrderReceive>> GetCRMByDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(DateTime dateTimeBegin, DateTime dateTimeEnd, string searchString);
    }
}
