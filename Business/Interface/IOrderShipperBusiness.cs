namespace Business.Interface
{
	public interface IOrderShipperBusiness : IBaseBusiness<OrderShipper>
	{
        Task<List<OrderShipper>> GetByYearAndMonthAndDayAndSearchStringToLisAsync(int year, int month, int day, string searchString);

    }
}
