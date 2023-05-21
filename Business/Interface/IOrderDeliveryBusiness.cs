namespace Business.Interface
{
	public interface IOrderDeliveryBusiness : IBaseBusiness<OrderDelivery>
	{
        Task<List<OrderDelivery>> Get01ByYearAndMonthAndDayAndSearchStringToLisAsync(int year, int month, int day, string searchString);
        Task<List<OrderDelivery>> Get02ByYearAndMonthAndDayAndSearchStringToLisAsync(int year, int month, int day, string searchString);
        Task<List<OrderDelivery>> Get03ByYearAndMonthAndDayAndSearchStringToLisAsync(int year, int month, int day, string searchString);

    }
}
