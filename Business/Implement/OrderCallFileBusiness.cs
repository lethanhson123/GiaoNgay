namespace Business.Implement
{
    public class OrderCallFileBusiness : BaseBusiness<OrderCallFile, IOrderCallFileRepository>, IOrderCallFileBusiness
    {
        private readonly IOrderCallFileRepository _orderCallFileRepository;
        private readonly IOrderCallBusiness _olrderCallBusiness;
        private readonly IOrderDeliveryBusiness _orderDeliveryBusiness;
        private readonly IOrderDeliveryFileBusiness _orderDeliveryFileBusiness;
        public OrderCallFileBusiness(IOrderCallFileRepository orderCallFileRepository
            , IOrderCallBusiness olrderCallBusiness
            , IOrderDeliveryBusiness orderDeliveryBusiness
            , IOrderDeliveryFileBusiness orderDeliveryFileBusiness) : base(orderCallFileRepository)
        {
            _orderCallFileRepository = orderCallFileRepository;
            _olrderCallBusiness = olrderCallBusiness;
            _orderDeliveryBusiness = orderDeliveryBusiness;
            _orderDeliveryFileBusiness = orderDeliveryFileBusiness;
        }
        public virtual async Task<OrderCallFile> Save01Async(OrderCallFile model, string webRootPath)
        {
            int result = GlobalHelper.InitializationNumber;
            Initialization(model);
            if (model.ID > 0)
            {
                result = await _orderCallFileRepository.UpdateAsync(model);
            }
            else
            {
                result = await _orderCallFileRepository.AddAsync(model);
            }
            if (result > 0)
            {
                OrderCall orderCall = await _olrderCallBusiness.GetByIDAsync(model.ParentID.Value);
                if ((orderCall != null) && (orderCall.ID > 0))
                {
                    OrderDelivery orderDelivery = new OrderDelivery();
                    orderDelivery.ParentID = orderCall.ID;
                    orderDelivery.DateCreated = orderCall.DateCreated;
                    orderDelivery.ShopID = orderCall.ShopID;
                    orderDelivery.ReceiveID = orderCall.ShipperID;
                    orderDelivery.ReceiveFullName = orderCall.ShipperFullName;
                    orderDelivery.ShopFullName = orderCall.ShopFullName;
                    orderDelivery.ShopAddress = orderCall.ShopAddress;
                    await _orderDeliveryBusiness.Save01Async(orderDelivery, webRootPath);
                    if (orderDelivery.ID > 0)
                    {
                        OrderDeliveryFile orderDeliveryFile = new OrderDeliveryFile();
                        orderDeliveryFile.Note = model.Note;
                        orderDeliveryFile.ParentID = orderDelivery.ID;
                        await _orderDeliveryFileBusiness.SaveAsync(orderDeliveryFile);
                    }
                }
            }
            return model;
        }
    }
}
