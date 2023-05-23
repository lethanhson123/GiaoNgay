namespace Business.Interface
{
	public interface IOrderDeliveryDetailBusiness : IBaseBusiness<OrderDeliveryDetail>
	{
        Task<int> AddEmptyAsync(long parentID);
    }
}
