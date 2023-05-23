namespace Business.Implement
{
	public class OrderReceiveDetailBusiness : BaseBusiness<OrderReceiveDetail, IOrderReceiveDetailRepository>, IOrderReceiveDetailBusiness
    {
		private readonly IOrderReceiveDetailRepository _OrderReceiveDetailRepository;
		public OrderReceiveDetailBusiness(IOrderReceiveDetailRepository OrderReceiveDetailRepository) : base(OrderReceiveDetailRepository)
		{
            _OrderReceiveDetailRepository = OrderReceiveDetailRepository;
		}		
	}
}
