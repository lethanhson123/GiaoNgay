namespace Business.Implement
{
	public class OrderShipperDetailBusiness : BaseBusiness<OrderShipperDetail, IOrderShipperDetailRepository>, IOrderShipperDetailBusiness
    {
		private readonly IOrderShipperDetailRepository _OrderShipperDetailRepository;
		public OrderShipperDetailBusiness(IOrderShipperDetailRepository OrderShipperDetailRepository) : base(OrderShipperDetailRepository)
		{
            _OrderShipperDetailRepository = OrderShipperDetailRepository;
		}		
	}
}
