namespace Business.Implement
{
	public class OrderShipperDetailBusiness : BaseBusiness<OrderShipperDetail, IOrderShipperDetailRepository>, IOrderShipperDetailBusiness
    {
		private readonly IOrderShipperDetailRepository _orderShipperDetailRepository;
		public OrderShipperDetailBusiness(IOrderShipperDetailRepository orderShipperDetailRepository) : base(orderShipperDetailRepository)
		{
            _orderShipperDetailRepository = orderShipperDetailRepository;
		}		
	}
}
