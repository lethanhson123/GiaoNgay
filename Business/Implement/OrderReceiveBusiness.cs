namespace Business.Implement
{
	public class OrderReceiveBusiness : BaseBusiness<OrderReceive, IOrderReceiveRepository>, IOrderReceiveBusiness
    {
		private readonly IOrderReceiveRepository _OrderReceiveRepository;
		public OrderReceiveBusiness(IOrderReceiveRepository OrderReceiveRepository) : base(OrderReceiveRepository)
		{
            _OrderReceiveRepository = OrderReceiveRepository;
		}		
	}
}
