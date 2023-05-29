namespace Data.Repository.Interface
{
    public interface IOrderCallRepository : IBaseRepository<OrderCall>
    {
        Task<List<OrderCall>> GetByOrderReceiveIDToListAsync(long orderReceiveID);
        Task<string> UpdateByIDAndActiveAndOrderReceiveIDAsync(long ID, bool active, long orderReceiveID);
    }
}
