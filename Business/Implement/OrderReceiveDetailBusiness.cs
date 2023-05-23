namespace Business.Implement
{
	public class OrderReceiveDetailBusiness : BaseBusiness<OrderReceiveDetail, IOrderReceiveDetailRepository>, IOrderReceiveDetailBusiness
    {
		private readonly IOrderReceiveDetailRepository _orderReceiveDetailRepository;
		public OrderReceiveDetailBusiness(IOrderReceiveDetailRepository orderReceiveDetailRepository) : base(orderReceiveDetailRepository)
		{
            _orderReceiveDetailRepository = orderReceiveDetailRepository;
		}		
	}
}
