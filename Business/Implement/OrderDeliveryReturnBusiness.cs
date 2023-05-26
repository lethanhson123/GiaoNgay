namespace Business.Implement
{
    public class OrderDeliveryReturnBusiness : BaseBusiness<OrderDeliveryReturn, IOrderDeliveryReturnRepository>, IOrderDeliveryReturnBusiness
    {
        private readonly IOrderDeliveryReturnRepository _orderDeliveryReturnRepository;
        public OrderDeliveryReturnBusiness(IOrderDeliveryReturnRepository orderDeliveryReturnRepository) : base(orderDeliveryReturnRepository)
        {
            _orderDeliveryReturnRepository = orderDeliveryReturnRepository;
        }
        public override void Initialization(OrderDeliveryReturn model)
        {
            model.Total = model.Quantity * model.Price;
        }
    }
}
