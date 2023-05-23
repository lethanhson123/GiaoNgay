namespace Business.Interface
{
	public interface IOrderDeliveryBusiness : IBaseBusiness<OrderDelivery>
	{
        Task<List<OrderDelivery>> Get01ByYearAndMonthAndDayAndSearchStringToLisAsync(int year, int month, int day, string searchString);
        Task<List<OrderDelivery>> Get02ByYearAndMonthAndDayAndSearchStringToLisAsync(int year, int month, int day, string searchString);
        Task<List<OrderDelivery>> Get03ByYearAndMonthAndDayAndSearchStringToLisAsync(int year, int month, int day, string searchString);
        Task<List<OrderDelivery>> Get04ByYearAndMonthAndDayAndSearchStringToLisAsync(int year, int month, int day, string searchString);
        Task<OrderDelivery> Save01Async(OrderDelivery model, string webRootPath);
        Task<List<OrderDelivery>> GetByOrderShipperIDToListAsync(long orderShipperID);
        Task<string> UpdateByIDAndActiveAndOrderShipperIDAsync(long ID, bool active, long orderShipperID);
        Task<List<OrderDelivery>> GetByOrderReceiveIDToListAsync(long orderReceiveID);
        Task<string> UpdateByIDAndActiveAndOrderReceiveIDAsync(long ID, bool active, long orderReceiveID);
    }
}
