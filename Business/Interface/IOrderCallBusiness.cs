namespace Business.Interface
{
	public interface IOrderCallBusiness : IBaseBusiness<OrderCall>
	{
        Task<OrderCall> ShipperSaveAsync(OrderCall model);
        Task<List<OrderCall>> GetByYearAndMonthAndDayAndSearchStringToLisAsync(int year, int month, int day, string searchString);
        Task<List<OrderCall>> GetByMembershipIDYearAndMonthAndDayAndSearchStringToLisAsync(long membershipID, int year, int month, int day, string searchString);
        Task<List<OrderCall>> GetCRMByDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(DateTime dateTimeBegin, DateTime dateTimeEnd, string searchString);
        Task<List<OrderCall>> GetByMembershipIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(long membershipID, DateTime dateTimeBegin, DateTime dateTimeEnd, string searchString);
        Task<List<OrderCall>> GetByOrderReceiveIDToListAsync(long orderReceiveID);
        Task<string> UpdateByIDAndActiveAndOrderReceiveIDAsync(long ID, bool active, long orderReceiveID);
        Task<List<OrderCall>> GetByMembershipIDAndCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(long membershipID, long categoryOrderStatusID, DateTime dateTimeBegin, DateTime dateTimeEnd, string searchString);
    }
}
