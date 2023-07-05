namespace Data.Repository.Interface
{
    public interface IOrderDeliveryRepository : IBaseRepository<OrderDelivery>
    {
        Task<List<OrderDelivery>> GetByOrderShipperIDToListAsync(long orderShipperID);
        Task<string> UpdateByIDAndActiveAndOrderShipperIDAsync(long ID, bool active, long orderShipperID);
        Task<List<OrderDelivery>> GetByOrderReceiveIDToListAsync(long orderReceiveID);
        Task<string> UpdateByIDAndActiveAndOrderReceiveIDAsync(long ID, bool active, long orderReceiveID);
        Task<string> UpdateByParentIDAndReceiveIDAndReceiveFullNameAsync(long parentID, long receiveID, string receiveFullName);
    }
}
