namespace Business.Implement
{
	public class OrderShipperBusiness : BaseBusiness<OrderShipper, IOrderShipperRepository>, IOrderShipperBusiness
    {
		private readonly IOrderShipperRepository _OrderShipperRepository;
		public OrderShipperBusiness(IOrderShipperRepository OrderShipperRepository) : base(OrderShipperRepository)
		{
            _OrderShipperRepository = OrderShipperRepository;
		}		
	}
}
