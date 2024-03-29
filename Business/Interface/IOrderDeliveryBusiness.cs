﻿namespace Business.Interface
{
	public interface IOrderDeliveryBusiness : IBaseBusiness<OrderDelivery>
	{
        string CreateQRCodeCCCD(string webRootPath, string QRCode);
        Task<List<OrderDelivery>> GetCRMByDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(DateTime dateTimeBegin, DateTime dateTimeEnd, string searchString);
        Task<List<OrderDelivery>> GetCRMByProvinceIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(long provinceID, DateTime dateTimeBegin, DateTime dateTimeEnd, string searchString);
        Task<List<OrderDelivery>> GetCRMByProvinceIDAndCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(long provinceID, long categoryOrderStatusID, DateTime dateTimeBegin, DateTime dateTimeEnd, string searchString);
        Task<List<OrderDelivery>> GetCRMByCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(long categoryOrderStatusID, DateTime dateTimeBegin, DateTime dateTimeEnd, string searchString);
        Task<OrderDelivery> Save01Async(OrderDelivery model, string webRootPath);
        Task<OrderDelivery> SaveMembershipAsync(OrderDelivery model);
        Task<OrderDelivery> SaveShopAsync(OrderDelivery model, string webRootPath);
        Task<List<OrderDelivery>> GetByOrderShipperIDToListAsync(long orderShipperID);
        Task<string> UpdateByIDAndActiveAndOrderShipperIDAsync(long ID, bool active, long orderShipperID);
        Task<List<OrderDelivery>> GetByOrderReceiveIDToListAsync(long orderReceiveID);
        Task<string> UpdateByIDAndActiveAndOrderReceiveIDAsync(long ID, bool active, long orderReceiveID);
        Task<string> UpdateByParentIDAsync(long parentID);
        Task<List<OrderDelivery>> GetByMembershipIDYearAndMonthAndDayAndSearchStringToLisAsync(long membershipID, int year, int month, int day, string searchString);
        Task<List<OrderDelivery>> GetByMembershipIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(long membershipID, DateTime dateTimeBegin, DateTime dateTimeEnd, string searchString);
        Task<List<OrderDelivery>> GetByMembershipIDAndProvinceIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(long membershipID, long provinceID, DateTime dateTimeBegin, DateTime dateTimeEnd, string searchString);
        Task<List<OrderDelivery>> GetCRMByShopIDAndIsCompleteShopListAsync(long shopID, bool isCompleteShop);
        Task<List<OrderDelivery>> GetByShipperIDAndIsCompleteShipperListAsync(long shipperID, bool isCompleteShipper);

        Task<List<OrderDelivery>> GetCRMByShopAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(long shopID, DateTime dateTimeBegin, DateTime dateTimeEnd, string searchString);
        Task<List<OrderDelivery>> GetCRMByShipperAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(long shipperID, DateTime dateTimeBegin, DateTime dateTimeEnd, string searchString);
        Task<List<OrderDelivery>> GetByMembershipIDAndCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(long membershipID, long categoryOrderStatusID, DateTime dateTimeBegin, DateTime dateTimeEnd, string searchString);
        Task<List<OrderDelivery>> GetByShipperIDAndCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(long shipperID, long categoryOrderStatusID, DateTime dateTimeBegin, DateTime dateTimeEnd, string searchString);
    }
}
