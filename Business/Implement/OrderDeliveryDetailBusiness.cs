namespace Business.Implement
{
    public class OrderDeliveryDetailBusiness : BaseBusiness<OrderDeliveryDetail, IOrderDeliveryDetailRepository>, IOrderDeliveryDetailBusiness
    {
        private readonly IOrderDeliveryDetailRepository _orderDeliveryDetailRepository;
        public OrderDeliveryDetailBusiness(IOrderDeliveryDetailRepository orderDeliveryDetailRepository) : base(orderDeliveryDetailRepository)
        {
            _orderDeliveryDetailRepository = orderDeliveryDetailRepository;
        }
        public virtual async Task<int> AddEmptyAsync(long parentID)
        {
            OrderDeliveryDetail model = new OrderDeliveryDetail();
            model.ParentID = parentID;
            model.Quantity = 1;
            model.Price = 0;
            Initialization(model);
            return await _orderDeliveryDetailRepository.AddAsync(model);
        }
    }
}
