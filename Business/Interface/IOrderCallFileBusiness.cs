namespace Business.Interface
{
	public interface IOrderCallFileBusiness : IBaseBusiness<OrderCallFile>
	{
        Task<OrderCallFile> Save01Async(OrderCallFile model, string webRootPath);

    }
}
