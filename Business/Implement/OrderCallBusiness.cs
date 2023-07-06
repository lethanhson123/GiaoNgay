namespace Business.Implement
{
    public class OrderCallBusiness : BaseBusiness<OrderCall, IOrderCallRepository>, IOrderCallBusiness
    {
        private readonly IOrderCallRepository _olrderCallRepository;
        private readonly IMembershipRepository _membershipRepository;
        private readonly IOrderDeliveryBusiness _orderDeliveryBusiness;
        public OrderCallBusiness(IOrderCallRepository orderCallRepository
            , IMembershipRepository membershipRepository
            , IOrderDeliveryBusiness orderDeliveryBusiness) : base(orderCallRepository)
        {
            _olrderCallRepository = orderCallRepository;
            _membershipRepository = membershipRepository;
            _orderDeliveryBusiness = orderDeliveryBusiness;
        }
        public override void Initialization(OrderCall model)
        {
            if (model.DateCreated == null)
            {
                model.DateCreated = GlobalHelper.InitializationDateTime;
            }
            if (model.DateCreated != null)
            {
                model.DateCreated = new DateTime(model.DateCreated.Value.Year, model.DateCreated.Value.Month, model.DateCreated.Value.Day, model.DateCreated.Value.Hour, model.DateCreated.Value.Minute, 0, 0);
            }
            if (model.ShopID != null)
            {
                Membership shop = _membershipRepository.GetByID(model.ShopID.Value);
                if (shop != null)
                {
                    model.ShopFullName = shop.Display;
                    model.ShopAddress = shop.Description;

                }
            }
            if (model.ShipperID != null)
            {
                Membership shipper = _membershipRepository.GetByID(model.ShipperID.Value);
                if (shipper != null)
                {
                    model.ShipperFullName = shipper.Display;
                    model.ShipperAddress = shipper.Description;
                }
            }
        }
        public virtual async Task<OrderCall> ShipperSaveAsync(OrderCall model)
        {
            int result = GlobalHelper.InitializationNumber;
            if (model.ID > 0)
            {
                OrderCall modelExist = await _olrderCallRepository.GetByIDAsync(model.ID);
                if (modelExist != null)
                {
                    modelExist.CategoryOrderStatusID = model.CategoryOrderStatusID;
                    modelExist.Note = model.Note;
                    result = await _olrderCallRepository.UpdateAsync(modelExist);
                    if (result > 0)
                    {
                        await _orderDeliveryBusiness.UpdateByParentIDAsync(model.ID);
                    }
                }
            }
            return model;
        }
        public override async Task<OrderCall> SaveAsync(OrderCall model)
        {
            int result = GlobalHelper.InitializationNumber;
            Initialization(model);
            if (model.ID > 0)
            {
                result = await _olrderCallRepository.UpdateAsync(model);
            }
            else
            {
                result = await _olrderCallRepository.AddAsync(model);
            }
            if (result > 0)
            {
                await _orderDeliveryBusiness.UpdateByParentIDAsync(model.ID);
            }
            return model;
        }
        public async Task<List<OrderCall>> GetBySearchStringToLisAsync(string searchString)
        {
            List<OrderCall> result = new List<OrderCall>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await _olrderCallRepository.GetByCondition(item => item.ShopFullName.Contains(searchString) || item.ShipperFullName.Contains(searchString)).ToListAsync();
            }
            return result;
        }
        public async Task<List<OrderCall>> GetByYearAndMonthAndDayAndSearchStringToLisAsync(int year, int month, int day, string searchString)
        {
            List<OrderCall> result = new List<OrderCall>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await GetBySearchStringToLisAsync(searchString);
            }
            else
            {
                try
                {
                    result = await _olrderCallRepository.GetByCondition(item => item.DateCreated.Value.Year == year && item.DateCreated.Value.Month == month && item.DateCreated.Value.Day == day).ToListAsync();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
            return result;
        }
        public async Task<List<OrderCall>> GetByMembershipIDAndSearchStringToLisAsync(long membershipID, string searchString)
        {
            List<OrderCall> result = new List<OrderCall>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await _olrderCallRepository.GetByCondition(item => (item.ShopID == membershipID || item.ShipperID == membershipID) && (item.ShopFullName.Contains(searchString) || item.ShipperFullName.Contains(searchString))).ToListAsync();
            }
            return result;
        }
        public async Task<List<OrderCall>> GetByMembershipIDYearAndMonthAndDayAndSearchStringToLisAsync(long membershipID, int year, int month, int day, string searchString)
        {
            List<OrderCall> result = new List<OrderCall>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await GetByMembershipIDAndSearchStringToLisAsync(membershipID, searchString);
            }
            else
            {
                try
                {
                    result = await _olrderCallRepository.GetByCondition(item => (item.ShopID == membershipID || item.ShipperID == membershipID) && (item.DateCreated.Value.Year == year && item.DateCreated.Value.Month == month && item.DateCreated.Value.Day == day)).ToListAsync();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
            return result;
        }

        public async Task<List<OrderCall>> GetCRMByDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(DateTime dateTimeBegin, DateTime dateTimeEnd, string searchString)
        {
            List<OrderCall> result = new List<OrderCall>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await GetBySearchStringToLisAsync(searchString);
            }
            else
            {
                try
                {
                    dateTimeBegin = new DateTime(dateTimeBegin.Year, dateTimeBegin.Month, dateTimeBegin.Day, 0, 0, 0);
                    dateTimeEnd = new DateTime(dateTimeEnd.Year, dateTimeEnd.Month, dateTimeEnd.Day, 23, 59, 59);
                    result = await _olrderCallRepository.GetByCondition(item => item.DateCreated >= dateTimeBegin && item.DateCreated <= dateTimeEnd).ToListAsync();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
            return result;
        }
        public async Task<List<OrderCall>> GetByMembershipIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(long membershipID, DateTime dateTimeBegin, DateTime dateTimeEnd, string searchString)
        {
            List<OrderCall> result = new List<OrderCall>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await GetByMembershipIDAndSearchStringToLisAsync(membershipID, searchString);
            }
            else
            {
                try
                {
                    dateTimeBegin = new DateTime(dateTimeBegin.Year, dateTimeBegin.Month, dateTimeBegin.Day, 0, 0, 0);
                    dateTimeEnd = new DateTime(dateTimeEnd.Year, dateTimeEnd.Month, dateTimeEnd.Day, 23, 59, 59);
                    result = await _olrderCallRepository.GetByCondition(item => (item.ShopID == membershipID || item.ShipperID == membershipID) && (item.DateCreated >= dateTimeBegin && item.DateCreated <= dateTimeEnd)).ToListAsync();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
            return result;
        }
        public async Task<List<OrderCall>> GetByMembershipIDAndCategoryOrderStatusIDAndDateTimeBeginAndDateTimeEndAndSearchStringToLisAsync(long membershipID, long categoryOrderStatusID, DateTime dateTimeBegin, DateTime dateTimeEnd, string searchString)
        {
            List<OrderCall> result = new List<OrderCall>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await GetByMembershipIDAndSearchStringToLisAsync(membershipID, searchString);
            }
            else
            {
                try
                {
                    dateTimeBegin = new DateTime(dateTimeBegin.Year, dateTimeBegin.Month, dateTimeBegin.Day, 0, 0, 0);
                    dateTimeEnd = new DateTime(dateTimeEnd.Year, dateTimeEnd.Month, dateTimeEnd.Day, 23, 59, 59);
                    result = await _olrderCallRepository.GetByCondition(item => item.Active == true && item.CategoryOrderStatusID == categoryOrderStatusID && (item.ShopID == membershipID || item.ShipperID == membershipID) && (item.DateCreated >= dateTimeBegin && item.DateCreated <= dateTimeEnd)).ToListAsync();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
            return result;
        }
        public async Task<List<OrderCall>> GetByOrderReceiveIDToListAsync(long orderReceiveID)
        {
            List<OrderCall> result = await _olrderCallRepository.GetByOrderReceiveIDToListAsync(orderReceiveID);
            return result;
        }
        public virtual async Task<string> UpdateByIDAndActiveAndOrderReceiveIDAsync(long ID, bool active, long orderReceiveID)
        {
            var result = await _olrderCallRepository.UpdateByIDAndActiveAndOrderReceiveIDAsync(ID, active, orderReceiveID);
            return result;
        }
    }
}
